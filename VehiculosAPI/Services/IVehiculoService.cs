using VehiculosAPI.Entities;

namespace VehiculosAPI.Services
{
    public interface IVehiculoService
    {
		Task<List<Vehiculo>> GetAllVehiculosAsync();
    }
}
