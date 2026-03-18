using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
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

		public async Task<bool> deleteVehiculoAsync(Vehiculo vehiculo)
		{
			var vehiculoExistente = await dbContext.Vehiculos.FindAsync(vehiculo.Id);
			dbContext.Remove(vehiculoExistente);
			var vehiculoEliminado = await dbContext.SaveChangesAsync();
			return vehiculoEliminado > 0;
		}

		public async Task<List<Vehiculo>> GetAllVehiculoFromDBAsync()
		{
			return await dbContext.Vehiculos.ToListAsync();

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

		public async Task<List<CatMarca>> SetVariasMarcasAsync(List<CatMarca> marcas)
		{
			await dbContext.AddRangeAsync(marcas);
			var nuevasMarcasGuardadas = await dbContext.SaveChangesAsync();
			return nuevasMarcasGuardadas > 0 ? marcas : null;



		}

		public async Task<Vehiculo> SetVehiculoAsync(Vehiculo vehiculo)
		{
			await dbContext.Vehiculos.AddAsync(vehiculo);
			var nuevoVehiculoGuardado = await dbContext.SaveChangesAsync();
			return nuevoVehiculoGuardado > 0 ? vehiculo : null;
		}

		public async Task<Vehiculo> updateVehiculoAsync(Vehiculo vehiculo)
		{
			var vehiculoExsitente = await dbContext.Vehiculos.FindAsync(vehiculo.Id);
			vehiculoExsitente.Modelo = "Vehiculo Editado";
			dbContext.Vehiculos.Update(vehiculoExsitente);
			var vehiculoEditado = await dbContext.SaveChangesAsync();
			return vehiculoEditado > 0 ? vehiculoExsitente : null;
		}
	}
}
