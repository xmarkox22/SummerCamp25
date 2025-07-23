// See https://aka.ms/new-console-template for more information
public class EjemploCalculadora
{
    public void Ejecutar()
    {

        // Definir el diccionario de operaciones con métodos
        Dictionary<string, Func<int, int, int>> operaciones = 
            new Dictionary<string, Func<int, int, int>>
        {
            { "Multiplicar", Multiplicar },
            { "Sumar", Sumar },
            { "Restar", Restar },
            { "Dividir", Dividir }
        };


        Console.ResetColor();
        Console.Clear();

        Console.WriteLine("Calculadora");
        // Interacción con el usuario
        Console.WriteLine("Calculadora");

        foreach (var operacion in operaciones.Keys)
        {
            Console.WriteLine(operacion);
        }
        Console.WriteLine("Elija una operación:");
        string opcion = Console.ReadLine();

        Console.WriteLine("Ingrese el primer número:");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo número:");
        int b = int.Parse(Console.ReadLine());

        try
        {
            if (operaciones.ContainsKey(opcion))
            {
                int resultado = operaciones[opcion](a, b);
                Console.WriteLine($"El resultado de {opcion} {a} y {b} es: {resultado}");
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
        }


        Console.ReadLine();

    }

    // Métodos para cada operación
     int Multiplicar(int a, int b)
    {
        return a * b;
    }

     int Sumar(int a, int b)
    {
        return a + b;
    }

     int Restar(int a, int b)
    {
        return a - b;
    }

     int Dividir(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("No se puede dividir por cero");
        }
        return a / b;
    }
}