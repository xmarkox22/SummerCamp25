namespace ApiPaisesProyecto.Utilidades
{
    public static class Extensiones
    {

        public static string ConvertirNombreAMayusculas(this string nombre)
        {
            return nombre.ToUpper() + "--";
        }

        public static bool EsMayorQue(this DateTime fecha, DateTime fechaComparar)
        {
            return fecha >= fechaComparar;
        }
    }
}
