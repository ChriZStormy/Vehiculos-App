using VehiculosAPI.Entities;
using VehiculosAPI.Entities.Catalogos;

namespace VehiculosAPI.Services
{
    public interface IVehiculoService
    {
		Task<List<Vehiculo>> GetAllVehiculosAsync();
        Task<CatMarca> SetMarcaAsync(CatMarca marca );
	}
}
