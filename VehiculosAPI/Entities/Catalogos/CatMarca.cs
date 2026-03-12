using System.Globalization;
using System.Security;

namespace VehiculosAPI.Entities.Catalogos
{
    public class CatMarca
    {
       public int Id { get; set; }
       public string marca { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }
	}
}
