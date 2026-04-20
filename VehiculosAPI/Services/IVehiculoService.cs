using VehiculosAPI.Entities;
using VehiculosAPI.Entities.Catalogos;

namespace VehiculosAPI.Services
{
    public interface IVehiculoService
    {
		Task<List<Vehiculo>> GetAllVehiculosAsync();
        Task<CatMarca> SetMarcaAsync(CatMarca marca );
        Task<List<CatMarca>> SetVariasMarcasAsync(List<CatMarca> marcas);

        Task<List<Vehiculo>> GetAllVehiculoFromDBAsync();
        Task<List<CatMarca>> GetAllMarcasFromDBAsync();

        Task<bool> deleteVehiculoAsync(int id);
        Task<Vehiculo> updateVehiculoAsync(Vehiculo vehiculo);
        Task<Vehiculo> SetVehiculoAsync(Vehiculo vehiculo);
	}
}
