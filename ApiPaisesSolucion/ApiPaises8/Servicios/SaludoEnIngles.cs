using ApiPaisesProyecto.Utilidades;

namespace ApiPaisesProyecto.Servicios
{
    // Crear una instancia de la interfaz ISaludo pero saludando en inglés
    public class SaludoEnIngles : ISaludo
    {
        public string saludar(string mensaje)
        {
            return  $"Hello {mensaje}".ConvertirNombreAMayusculas();
        }
    }
}
