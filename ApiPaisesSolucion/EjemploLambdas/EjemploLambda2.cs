// See https://aka.ms/new-console-template for more information

public class EjemploLambda2
{
    public EjemploLambda2()
    {
    }


    int Multiplicar(int a, int b)
    {
        return a * b;
    }

    int Sumar(int a, int b)
    {
        return a + b;
    }

    public void EjemploDelegados2()
    {
        
        int a = 10;
        int b = 20;


        // Delegado asignando metodo
        Func<int, int, int> MultiplyDelegate;
        MultiplyDelegate = Multiplicar;

        int resultado = MultiplyDelegate(a, b);


        // Delegado mediante metodo anonimo
        Func<int, int, string> MultiplicarDelegado2 = (a, b) =>
        {
            var operador1 = a;
            var operador2 = b;

            return $"El resultado de multiplicar {operador1} por {operador2} es {operador1 * operador2}";

        };
        string producto = MultiplicarDelegado2(a, b);
        Console.WriteLine(producto);


        List<Func<int, int, int>> operaciones = new List<Func<int, int, int>>();

operaciones.Add(Multiplicar);
        operaciones.Add(Sumar);

      



    }
}