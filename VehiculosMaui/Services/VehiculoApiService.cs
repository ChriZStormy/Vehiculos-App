using System.Net.Http.Json;
using VehiculosMaui.Models;

namespace VehiculosMaui.Services
{
	public class VehiculoApiService
	{
		private readonly HttpClient _httpClient;

		// URL base de tu API (Ajusta el puerto si es distinto. 10.0.2.2 es para el emulador Android)
		private readonly string _baseUrl = "http://10.0.2.2:5000/api/vehiculo";

		public VehiculoApiService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<bool> RegistrarVehiculoAsync(Vehiculo vehiculo)
		{
			try
			{
				// El endpoint en tu controlador es [HttpPost("nuevovehiculo")]
				var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/nuevovehiculo", vehiculo);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al conectar con la API: {ex.Message}");
				return false;
			}
		}

		public async Task<List<Vehiculo>> GetVehiculosAsync()
		{
			try
			{
				return await _httpClient.GetFromJsonAsync<List<Vehiculo>>($"{_baseUrl}/todosvehiculos");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al obtener vehículos: {ex.Message}");
				return new List<Vehiculo>();
			}
		}

		public async Task<bool> ActualizarVehiculoAsync(Vehiculo vehiculo)
		{
			try
			{
				var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/actualizarvehiculo", vehiculo);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al conectar con la API: {ex.Message}");
				return false;
			}
		}

		public async Task<bool> EliminarVehiculoAsync(int id)
		{
			try
			{
				var response = await _httpClient.DeleteAsync($"{_baseUrl}/eliminarvehiculo/{id}");
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al conectar con la API: {ex.Message}");
				return false;
			}
		}
	}
}