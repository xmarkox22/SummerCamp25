namespace ApiPaisesProyecto.Models
{
    public class DistritoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string? DireccionJuntaDistrital { get; set; }

        public string? Responsable { get; set; }

        public int Antiguedad { get; set; }
    }
}
