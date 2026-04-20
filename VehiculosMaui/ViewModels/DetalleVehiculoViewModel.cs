using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VehiculosMaui.Models;
using VehiculosMaui.Services;
using VehiculosMaui.Views;

namespace VehiculosMaui.ViewModels
{
    [QueryProperty(nameof(VehiculoSeleccionado), "VehiculoSeleccionado")]
    public class DetalleVehiculoViewModel : INotifyPropertyChanged
    {
        private readonly VehiculoApiService _apiService;
        private Vehiculo _vehiculoSeleccionado;

        public Vehiculo VehiculoSeleccionado
        {
            get => _vehiculoSeleccionado;
            set
            {
                _vehiculoSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditarCommand { get; }
        public ICommand EliminarCommand { get; }

        public DetalleVehiculoViewModel()
        {
            _apiService = new VehiculoApiService();
            EditarCommand = new Command(async () => await EditarVehiculo());
            EliminarCommand = new Command(async () => await EliminarVehiculo());
        }

        private async Task EditarVehiculo()
        {
            if (VehiculoSeleccionado == null) return;
            var navigationParameter = new Dictionary<string, object>
            {
                { "VehiculoAEditar", VehiculoSeleccionado }
            };
            await Shell.Current.GoToAsync(nameof(EditarVehiculoPage), navigationParameter);
        }

        private async Task EliminarVehiculo()
        {
            if (VehiculoSeleccionado == null) return;

            bool confirmar = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Deseas eliminar este vehículo?", "Sí", "No");
            if (confirmar)
            {
                bool exito = await _apiService.EliminarVehiculoAsync(VehiculoSeleccionado.Id);
                if (exito)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Vehículo eliminado.", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el vehículo.", "OK");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
