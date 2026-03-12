using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using VehiculosAPI.Entities;
using VehiculosAPI.Services;

namespace VehiculosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService vehiculoSercvice;

        public VehiculoController(IVehiculoService vehiculoSercvice)
        {
            this.vehiculoSercvice = vehiculoSercvice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vehiculo>>> GetAllVehiculos()
        {
            var vehiculos = await vehiculoSercvice.GetAllVehiculosAsync();


            if (vehiculos.Count == 0){

                return NoContent();
            }
            else
            {
				return Ok(vehiculos);
			}
		}
       
    }
}
