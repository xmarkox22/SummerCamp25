using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaisesProyecto.Entidades
{
    public class Distrito
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public string? DireccionJuntaDistrital { get; set; }

        public string? Responsable { get; set; }

        public DateTime FechaFundacion { get; set; } = DateTime.Now;
    }
}
