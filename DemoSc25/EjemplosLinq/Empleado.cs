using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosLinq
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioMensual { get; set; }
        public int AntiguedadAnios { get; set; }

        // Campos agregados por procesos
        public decimal SalarioAnual { get; set; }
        public int DiasVacaciones { get; set; }
        public string ClasificacionSalarial { get; set; }
        public decimal Bonificacion { get; set; }
        public int EdadEstimada { get; set; }
        public DateTime FechaEstimacionAscenso { get; internal set; }
        public int HorasTrabajadasAnuales { get; set; } = 2080; // Asumiendo 40 horas semanales y 50 semanas al año
        public string PlanSalud { get; internal set; }
        public int revisionContrato { get; internal set; }
        public string RiesgoFuga { get; internal set; }
    }
}
