using VehiculosAPI.Data;
using VehiculosAPI.Entities;
using VehiculosAPI.Entities.Catalogos;

namespace VehiculosAPI.Services
{
    public class VehiculoService : IVehiculoService
    {
		private readonly ApplicationDbContext dbContext;

		public VehiculoService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
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

		public async Task<CatMarca> SetMarcaAsync(CatMarca marca)
		{
			await dbContext.CatMarcas.AddAsync(marca);
			var nuevaMarcaGuardada = await dbContext.SaveChangesAsync();
			return nuevaMarcaGuardada > 0 ? marca : null;

		}
	}
}
