using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VehiculosMaui.Models;
using VehiculosMaui.Services;

namespace VehiculosMaui.ViewModels
{
	public class RegistrarVehiculoViewModel : INotifyPropertyChanged
	{
		private readonly VehiculoApiService _apiService;

		private string _modelo;
		private string _year; // Cambiado a string
		private string _placas;
		private int _marcaId;

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

		public RegistrarVehiculoViewModel()
		{
			_apiService = new VehiculoApiService();
			GuardarCommand = new Command(async () => await GuardarVehiculo());
		}

		private async Task GuardarVehiculo()
		{
			// Validaciones
			if (string.IsNullOrWhiteSpace(Modelo) || string.IsNullOrWhiteSpace(Year) || string.IsNullOrWhiteSpace(Placas))
			{
				await Application.Current.MainPage.DisplayAlert("Aviso", "Por favor llena todos los campos.", "OK");
				return;
			}

			var vehiculo = new Vehiculo
			{
				Modelo = this.Modelo,
				Year = this.Year, // Ahora es string
				Placas = this.Placas,
				MarcaId = this.MarcaId
			};

			bool exito = await _apiService.RegistrarVehiculoAsync(vehiculo);

			if (exito)
			{
				await Application.Current.MainPage.DisplayAlert("Éxito", "Vehículo registrado en la base de datos.", "OK");
				await Shell.Current.GoToAsync(".."); // Regresar al inicio
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Error", "No se pudo conectar con la API.", "OK");
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}