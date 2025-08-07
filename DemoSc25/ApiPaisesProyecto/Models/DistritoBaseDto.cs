using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace ApiPaisesProyecto.Models
{
    public class DistritoBaseDto : IValidatableObject
    {
 
      
    


        [Required]
        public string Nombre { get; set; }
        [MaxLength(30)]
        public string? DireccionJuntaDistrital { get; set; }
        [MaxLength(30)]
        public string? Responsable { get; set; }
        public DateTime FechaFundacion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaFundacion > DateTime.Now)
            {
                yield return new ValidationResult("La fecha de fundación no puede ser futura.", new[] { nameof(FechaFundacion) });
            }
            // Nombre y DireccionjuntaDistrital no pueden ser iguales
            if (Nombre == DireccionJuntaDistrital)
            {
                yield return new ValidationResult("El nombre del distrito y la dirección de la junta distrital no pueden ser iguales.", new[] { nameof(Nombre), nameof(DireccionJuntaDistrital) });
            }
            // Responsable no puede ser igual a Nombre
            if (Responsable == Nombre)
            {
                yield return new ValidationResult("El responsable no puede ser el mismo que el nombre del distrito.", new[] { nameof(Responsable), nameof(Nombre) });
            }
            // DireccionJuntaDistrital no puede ser igual a Responsable
            if (DireccionJuntaDistrital == Responsable)
            {
                yield return new ValidationResult("La dirección de la junta distrital no puede ser igual al responsable.", new[] { nameof(DireccionJuntaDistrital), nameof(Responsable) });
            }
        }
    }
}
