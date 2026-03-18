using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using VehiculosAPI.Entities;
using VehiculosAPI.Entities.Catalogos;
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


            if (vehiculos.Count == 0)
            {

                return NoContent();
            }
            else
            {
                return Ok(vehiculos);
            }
        }

        [HttpPost("nuevamarca")]
        public async Task<ActionResult<CatMarca>> SetMarca([FromBody] CatMarca marca)
        {
            var nuevaMarca = await vehiculoSercvice.SetMarcaAsync(marca);
            if (nuevaMarca == null)
            {
                return BadRequest("No se pudo guardar la marca");
            }
            else
            {
                return Ok(nuevaMarca);
            }

        }

        [HttpPost("nuevovehiculo")]
        public async Task<ActionResult<Vehiculo>> SetVehiculo([FromBody] Vehiculo vehiculo)
        {
            var nuevoVehiculo = await vehiculoSercvice.SetVehiculoAsync(vehiculo);
            if (nuevoVehiculo == null)
            {
                return BadRequest("No se pudo guardar el vehiculo");
            }
            else
            {
                return Ok(nuevoVehiculo);
            }
        }

        [HttpGet("todosvehiculos")]
        public async Task<ActionResult<List<Vehiculo>>> GetAllVehiculosFromDB()
        {
            var vehiculos = await vehiculoSercvice.GetAllVehiculoFromDBAsync();
            if (vehiculos.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(vehiculos);
            }
        }

        [HttpDelete("eliminarvehiculo")]
        public async Task<ActionResult<bool>> DeleteVehiculo([FromBody] Vehiculo vehiculo)
        {
            var vehiculoEliminado = await vehiculoSercvice.deleteVehiculoAsync(vehiculo);
            if (!vehiculoEliminado)
            {
                return BadRequest("No se pudo eliminar el vehiculo. ");
            }
            else
            {
                return Ok("Vehiculo Eliminado Existosamente");
            }
        }


        [HttpPut("actualizarvehiculo")]
        public async Task<ActionResult<Vehiculo>> UpdateVehiculo([FromBody] Vehiculo vehiculo)
        {
            var vehiculoActualizado = await vehiculoSercvice.updateVehiculoAsync(vehiculo);
            if (vehiculoActualizado == null)
            {
                return BadRequest("No se pudo actualizar el vehiculo");
            }
            else
            {
                return Ok(vehiculoActualizado);
            }

        }
    }
}
