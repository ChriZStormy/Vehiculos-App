using VehiculosAPI.Entities;

namespace VehiculosAPI.Services
{
    public class VehiculoService : IVehiculoService
    {
        public async Task<List<Vehiculo>> GetAllVehiculosAsync()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>
            {
                new Vehiculo { Id = 1, MarcaId = 1, Modelo = "Corolla", Year = "2020", Placas = "ABC123" },
                new Vehiculo { Id = 2, MarcaId = 2, Modelo = "Civic", Year = "2021", Placas = "DEF456" },
                new Vehiculo { Id = 3, MarcaId = 3, Modelo = "Focus", Year = "2022", Placas = "GHI789" }
            };

            return vehiculos;
		}
    }
}
