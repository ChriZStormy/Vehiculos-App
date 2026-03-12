using VehiculosAPI.Entities.Catalogos;

namespace VehiculosAPI.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int  MarcaId { get; set; }

        public CatMarca? Marca { get; set; }



		public string Modelo { get; set; }

		public string Year { get; set; }

		public string Placas { get; set; }
	}
}
