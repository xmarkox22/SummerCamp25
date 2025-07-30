namespace ApiPaisesProyecto.Entidades
{
    /// <summary>
    /// 1 - Crear entidad Apartamento
    /// </summary>
    public class Apartamento
    {
        public int Id { get; internal set; }
        public string Nombre { get; internal set; }
        public string Ciudad { get; internal set; }

        public string Puerta { get; set; }

        public Edificio Edificio { get; set; }

    }
}
