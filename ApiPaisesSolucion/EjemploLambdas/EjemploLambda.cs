using System.Security.Cryptography.X509Certificates;

namespace ApiPaisesProyecto.Utilidades;

public class EjemploLambda
{
    //                1             2
    public delegate string Delegado();

    //public int MyProperty { get; set; }

    //      1             2


    //      1                                 2               
    public string CalcularDistanciaTierraLuna()
    {
       return "384.400 km";
    }

    //      1                                2
    public string CalcularDistanciaTierraSol()
    {
        return "149.600.000 km";
    }

    public void EjemploDelegados1()
    {

        Delegado delegado = new Delegado(Saludar);
        Delegado delegado2 = new Delegado(CalcularDistanciaTierraLuna);
        Delegado delegado3 = new Delegado(CalcularDistanciaTierraSol);

        List<Delegado> delegados = new List<Delegado>();
        delegados.Add(delegado);
        delegados.Add(delegado2);
        delegados.Add(delegado3);

        foreach (var item in delegados)
        {
            Console.WriteLine(item());
        }
        delegados.Select(x => x()).ToList().ForEach(x => Console.WriteLine(x));


        Func<string> delegadoFunc = () => "Hola Mundo";
        Func<int> delegadoFunc2 = () => 100000;

        Console.WriteLine(delegadoFunc());
        Console.WriteLine(delegadoFunc2());

        Func<string> HolaMundoBloque = () =>
        {
            Func<string> HolaMundo = () =>
            {
                Func<string> HolaMundo2 = () =>
                {
                    return "Hola Mundo";
                };
                return HolaMundo2();
            };

            return HolaMundo();

        };


        Console.WriteLine(HolaMundoBloque());


        Func<string> holaMundoDelegadoMetodo = Saludar;
        Func<string> holaMundoDelegadoMetodo3 = Saludar;
        Func<int> holaMundoDelegadoMetodo2 = CalculoNumero;
        Console.WriteLine(holaMundoDelegadoMetodo());
        Console.WriteLine(holaMundoDelegadoMetodo2());


    }

    public string Saludar()
    {
        return "Hola Mundo";
    }
    public int CalculoNumero()
    {
        return 100000;
    }
}