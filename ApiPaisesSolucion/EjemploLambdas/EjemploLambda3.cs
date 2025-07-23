// See https://aka.ms/new-console-template for more information

public class EjemploLambda3
{
    public EjemploLambda3()
    {
    }


   public void Accion(int a)
    {
        Console.WriteLine($"Estamos en el metodo {a}");
    }

    public void ProbarAccion(Action<int> accion, int numero)
    {
        accion(numero);
    }

    public void EjemploDelegados3()
    {
        
        ProbarAccion(Accion, 100);

        ProbarAccion((a) => Console.WriteLine($"Estamos en el metodo {a}"), 200);


        Action<int> accion = (a) => Console.WriteLine($"Estamos en el metodo {a}");
        ProbarAccion(accion, 300);

    }
}