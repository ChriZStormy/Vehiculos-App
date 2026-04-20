using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VehiculosMaui.Models;
using VehiculosMaui.Services;

namespace VehiculosMaui.ViewModels
{
    [QueryProperty(nameof(VehiculoAEditar), "VehiculoAEditar")]
    public class EditarVehiculoViewModel : INotifyPropertyChanged
    {
        private readonly VehiculoApiService _apiService;
        private Vehiculo _vehiculoAEditar;

        private string _modelo;
        private string _year;
        private string _placas;
        private int _marcaId;

        public Vehiculo VehiculoAEditar
        {
            get => _vehiculoAEditar;
            set
            {
                _vehiculoAEditar = value;
                if (_vehiculoAEditar != null)
                {
                    Modelo = _vehiculoAEditar.Modelo;
                    Year = _vehiculoAEditar.Year;
                    Placas = _vehiculoAEditar.Placas;
                    MarcaId = _vehiculoAEditar.MarcaId;
                }
                OnPropertyChanged();
            }
        }

        public string Modelo
        {
            get => _modelo;
            set { _modelo = value; OnPropertyChanged(); }
        }
        public string Year
        {
            get => _year;
            set { _year = value; OnPropertyChanged(); }
        }
        public string Placas
        {
            get => _placas;
            set { _placas = value; OnPropertyChanged(); }
        }
        public int MarcaId
        {
            get => _marcaId;
            set { _marcaId = value; OnPropertyChanged(); }
        }

        public ICommand GuardarCommand { get; }

        public EditarVehiculoViewModel()
        {
            _apiService = new VehiculoApiService();
            GuardarCommand = new Command(async () => await GuardarVehiculo());
        }

        private async Task GuardarVehiculo()
        {
            if (string.IsNullOrWhiteSpace(Modelo) || string.IsNullOrWhiteSpace(Year) || string.IsNullOrWhiteSpace(Placas))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Por favor llena todos los campos.", "OK");
                return;
            }

            var vehiculoEditado = new Vehiculo
            {
                Id = VehiculoAEditar.Id,
                Modelo = this.Modelo,
                Year = this.Year,
                Placas = this.Placas,
                MarcaId = this.MarcaId
            };

            bool exito = await _apiService.ActualizarVehiculoAsync(vehiculoEditado);

            if (exito)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Vehículo actualizado.", "OK");
                await Shell.Current.Navigation.PopToRootAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo actualizar el vehículo.", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
