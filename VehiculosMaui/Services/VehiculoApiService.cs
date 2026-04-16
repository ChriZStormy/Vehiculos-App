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
	}
}