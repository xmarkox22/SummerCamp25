namespace ApiPaisesProyecto.Servicios
{
    public class Saludo : ISaludo
    {
        public string saludar(string mensaje)
        {
           return $"Hola {mensaje}";
        }
    }
}
