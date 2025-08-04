namespace ApiPaisesProyecto.Entidades
{
    public class Edificio
    {
        /// <summary>
        /// 1 - Crear entidad Edificio
        /// </summary>
        public int Id { get; internal set; }
        public string Nombre { get; internal set; }
        public string? Ciudad { get; internal set; }
        public string? Direccion { get; set; }
        public int? NumeroDePisos { get; set; }

        public Distrito Distrito { get; set; }

    }
}
