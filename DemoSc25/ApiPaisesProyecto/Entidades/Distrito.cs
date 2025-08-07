using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPaisesProyecto.Entidades
{

    [Table("Distritos")]
    public class Distrito
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del distrito es obligatorio.")]
        public string Nombre { get; set; }

        [MaxLength(100, ErrorMessage = "El nombre del distrito no puede exceder los 100 caracteres.")]
        public string? DireccionJuntaDistrital { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre del responsable no puede exceder los 50 caracteres.")]
        public string? Responsable { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaFundacion { get; set; } = DateTime.Now;
    }
}
