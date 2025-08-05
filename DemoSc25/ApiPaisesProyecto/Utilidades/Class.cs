namespace ApiPaisesProyecto.Utilidades
{
    public static class Utilidades
    {

        public static string ConvertirMayusculas(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }
            return texto.ToUpper()+"---------------";
        }

        public static string CapitalizarPrimeraLetra(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return texto;
            return char.ToUpper(texto[0]) + texto.Substring(1);
        }

        public static bool EsPar(this int numero)
        {
            return numero % 2 == 0;
        }


        public static int CalcularAntiguedad(this DateTime fecha)
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - fecha.Year;
            if (fecha > hoy.AddYears(-edad)) edad--;
            return edad;
        }



    }
}
