
internal class EjemploBasico
{
    public EjemploBasico()
    {
    }

    internal void Ejecutar()
    {
        string[] niveles = { "Basico", "Intermedio", "Avanzado" };
        int nc = niveles.Count();

        // Selecciona todos los niveles cuya longitud en caracteres
        // sea mayor que 6
        // ordenado por nivel alfabéticamente

        List<string> nivelesMayores6 = new List<string>();

        
        foreach (var nivel in niveles)
        {
            if (nivel.Length > 6)
            {
                nivelesMayores6.Add(nivel);
                Console.WriteLine(nivel);
            }
        }

        // Implementación de Bubble Sort para ordenar la lista alfabéticamente
        for (int i = 0; i < nivelesMayores6.Count - 1; i++)
        {
            for (int j = 0; j < nivelesMayores6.Count - i - 1; j++)
            {
                if (string.Compare(nivelesMayores6[j], nivelesMayores6[j + 1]) > 0)
                {
                    // Intercambiar nivelesMayores6[j] y nivelesMayores6[j + 1]
                    string temp = nivelesMayores6[j];
                    nivelesMayores6[j] = nivelesMayores6[j + 1];
                    nivelesMayores6[j + 1] = temp;
                }
            }
        }

        // Imprime los niveles ordenados
        foreach (var nivel in nivelesMayores6)
        {
            Console.WriteLine(nivel);
        }

        // Selecciona todos los niveles cuya longitud en caracteres
        // sea mayor que 6
        // ordenado por nivel alfabéticamente

        // Tabla: Niveles
        // +-----------------+
        // | Nivel           |
        // +-----------------+
        // | Intermedio      |
        // | Avanzado        |
        // | Basic           |
        // +-----------------+

        // En SQL sería algo como:
        // SELECT Nivel
        // FROM Niveles
        // WHERE LEN(Nivel) > 6
        // ORDER BY Nivel;

        // En LINQ sería algo como:
        var nivelesMayores6Linq = from nivel in niveles
                                  where nivel.Length > 6
                                  orderby nivel
                                  select nivel;

        // Con sintaxis de metodos seria algo como:
        var nivelesMayores6LinqMetodos = niveles.Where(nivel => nivel.Length > 6)
                                                 .OrderBy(nivel => nivel);






    }
}