using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VehiculosMaui.Models;
using VehiculosMaui.Services;
using VehiculosMaui.Views;

namespace VehiculosMaui.ViewModels
{
    public class ListaVehiculosViewModel : INotifyPropertyChanged
    {
        private readonly VehiculoApiService _apiService;
        private ObservableCollection<Vehiculo> _vehiculos;

        public ObservableCollection<Vehiculo> Vehiculos
        {
            get => _vehiculos;
            set { _vehiculos = value; OnPropertyChanged(); }
        }

        public ICommand CargarVehiculosCommand { get; }
        public ICommand VerDetalleCommand { get; }

        public ListaVehiculosViewModel()
        {
            _apiService = new VehiculoApiService();
            Vehiculos = new ObservableCollection<Vehiculo>();
            
            CargarVehiculosCommand = new Command(async () => await CargarVehiculos());
            VerDetalleCommand = new Command<Vehiculo>(async (v) => await VerDetalle(v));
        }

        public async Task CargarVehiculos()
        {
            var vehiculosApi = await _apiService.GetVehiculosAsync();
            Vehiculos.Clear();
            foreach (var v in vehiculosApi)
            {
                Vehiculos.Add(v);
            }
        }

        private async Task VerDetalle(Vehiculo vehiculo)
        {
            if (vehiculo == null) return;
            
            var navigationParameter = new Dictionary<string, object>
            {
                { "VehiculoSeleccionado", vehiculo }
            };
            await Shell.Current.GoToAsync(nameof(DetalleVehiculoPage), navigationParameter);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
