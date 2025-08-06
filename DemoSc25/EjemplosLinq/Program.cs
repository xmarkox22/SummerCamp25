// See https://aka.ms/new-console-template for more information
using EjemplosLinq;
using System.Diagnostics;
using System.Diagnostics.Metrics;

Console.WriteLine("Hello, World!");

//Ejemplo1();

//Ejemplo2();

//Ejemplo3();

//Ejemplo4();

//Ejemplo5();


Ejemplo6();


static void Ejemplo6()
{

    // Lista de empleados
    IEnumerable<Empleado> empleados = new List<Empleado>()
         {

             new Empleado
             {
                 Nombre = "Juan",
                 Apellidos = "Hernandez",
                 Ciudad = "Madrid",
                 Telefono = "123456789",
                 Edad = 25,
                 Departamento = Departamento.Desarrollo
             },
             new Empleado
             {
                 Nombre = "Luisa",
                 Apellidos = "Martinez",
                 Ciudad = "Madrid",
                 Telefono = "423456789",
                 Edad = 26,
                 Departamento= Departamento.Desarrollo
             },
             new Empleado
             {
                 Nombre = "Juan",
                 Apellidos = "Nuñez",
                 Ciudad = "Barcelona",
                 Telefono = "9123456789",
                 Edad = 32,
                 Departamento = Departamento.Admin
             },
             new Empleado
             {
                 Nombre = "Maria",
                 Apellidos = "Garcia",
                 Ciudad = "Valencia",
                 Telefono = "8123456789",
                 Edad = 23,
                 Departamento = Departamento.Desarrollo
             },
             new Empleado
         {
                 Nombre = "Rita",
                 Apellidos = "Martinez",
                 Ciudad = "Valencia",
                 Telefono = "8123456789",
                 Edad = 21,
                  Departamento = Departamento.Admin
             } };


    // Listado de los  telefonos de los empleados de Madrid
    // que contengan en su apellido una "a"
    // que esten en el departamento de desarrollo
    // ordenado por nombre


    // Sintaxis de consulta
    
    
    
    
    var resultado = from empleado in empleados
                    where empleado.Ciudad == "Madrid" &&
                          empleado.Apellidos.Contains("a") 
                    select empleado;


    var desarrollo = (from empleado in resultado
                     where empleado.Departamento == Departamento.Desarrollo
                     select empleado.Telefono).ToList();


    var resultadoLista = desarrollo.ToList();


    foreach (var telefono in desarrollo)
    {
        Console.WriteLine(telefono);
    }



    // Sintaxis de métodos en dos partes
    IEnumerable<Empleado> resultadoMetodos = empleados
        .Where(empleado => empleado.Ciudad == "Madrid" && empleado.Apellidos.Contains("a"));

    List<string> resultadoDepartamento = resultadoMetodos
        .Where(empleado => empleado.Departamento == Departamento.Desarrollo)
        .OrderBy(empleado => empleado.Nombre)
        .Select(empleado => empleado.Telefono)
        .ToList();




}


static void Ejemplo5() {

    string[] niveles = { "Basico", "Intermedio", "Avanzado" };


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

    // En C# con LINQ sería algo como:
    
    
    // Sintaxis SQL
    var nivelesMayores6Linq = from nivel in niveles
                              where nivel.Length > 6
                              orderby nivel
                              select nivel;



    // Sintaxis de Métodos

    var nivelesMayores6LinqMetodos = niveles.Where(nivel => nivel.Length > 6)
                                            .OrderBy(nivel => nivel)
                                            .Select(nivel => nivel);





}











static void Ejemplo4()
{
    string[] niveles = { "Basico", "Intermedio", "Avanzado" };
    int nc = niveles.Count();

    // Selecciona todos los niveles cuya longitud en caracteres
    // sea mayor que 6
    // ordenado por nivel alfabéticamente

    List<string> nivelesMayores6 = new List<string>();

    foreach (string nivel in niveles)
    {
        if (nivel.Length > 6)
        {
            nivelesMayores6.Add(nivel);
        }
    }

    // Ordenar alfabéticamente con el algoritmo de ordenación Bubble Sort
    for (int i = 0; i < nivelesMayores6.Count - 1; i++)
    {
        for (int j = 0; j < nivelesMayores6.Count - i - 1; j++)
        {
            if (string.Compare(nivelesMayores6[j], nivelesMayores6[j + 1]) > 0)
            {
                // Intercambiar
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

     

}


static void Ejemplo3()
{

    // 1. Lista de empleados
    List<EmpleadoAnterior> empleados = new List<EmpleadoAnterior>
        {
            new EmpleadoAnterior { Nombre = "Ana", Cargo = "Administrativa", SalarioMensual = 1800m, AntiguedadAnios = 3 },
            new EmpleadoAnterior { Nombre = "Luis", Cargo = "Técnico", SalarioMensual = 2200m, AntiguedadAnios = 5 },
            new EmpleadoAnterior { Nombre = "Marta", Cargo = "Jefa de Proyecto", SalarioMensual = 3500m, AntiguedadAnios = 10 }
        };

    // 2. Lista de procesos FUNC que modifican al empleado y lo devuelven
    List<Func<EmpleadoAnterior, EmpleadoAnterior>> procesos = new List<Func<EmpleadoAnterior, EmpleadoAnterior>>();

    // Proceso 1: Calcular salario anual
    procesos.Add(e =>
    {
        e.SalarioAnual = e.SalarioMensual * 12;
        return e;
    });

    // Proceso 2: Calcular días de vacaciones (22 + antigüedad)
    procesos.Add(e =>
    {
        e.DiasVacaciones = 22 + e.AntiguedadAnios;
        return e;
    });

    // Proceso 3: Clasificar salario
    procesos.Add(e =>
    {
        if (e.SalarioMensual > 3000)
            e.ClasificacionSalarial = "ALTO";
        else if (e.SalarioMensual >= 2000)
            e.ClasificacionSalarial = "MEDIO";
        else
            e.ClasificacionSalarial = "BAJO";
        return e;
    });

    // Proceso 4: Calcular bonificación por antigüedad (5% por año)
    procesos.Add(e =>
    {
        e.Bonificacion = e.SalarioMensual * 0.05m * e.AntiguedadAnios;
        return e;
    });


    // Calcular fecha estimada de ascenso
    // Si antigüedad > 5 años, se estima ascenso el próximo año, si no, en 3 años.

        procesos.Add(e =>
    {
        e.FechaEstimacionAscenso = DateTime.Now.AddYears(e.AntiguedadAnios > 5 ? 1 : 3);
        return e;
    });

    // Evaluar riesgo de rotación (fuga)
    // Si salario bajo y antigüedad alta → riesgo alto.
    procesos.Add(e => {
        if ((e.SalarioAnual / e.AntiguedadAnios) > 0.01m)
            e.RiesgoFuga = "ALTO";
        else
            e.RiesgoFuga = "Bajo";

        return e;
    });

    // Calcular horas trabajadas anuales
    // Supone 40 horas / semana × 52 semanas = 2080 horas / año.Puedes personalizar por cargo

    procesos.Add(e =>
    {
        if (e.Cargo == "Administrativa") e.HorasTrabajadasAnuales = 2000; // 50 semanas
        else if (e.Cargo == "Técnico") e.HorasTrabajadasAnuales = 2080; // 52 semanas
        else if (e.Cargo == "Jefa de Proyecto") e.HorasTrabajadasAnuales = 1800; // 45 semanas
        return e;
    });

    // Asignar plan de salud según cargo
    // Operativo: Básico / Técnico: Estándar / Directivo: Premium
    procesos.Add(e =>
    {
        if (e.Cargo == "Operativo")
            e.PlanSalud = "Basico";
        else if (e.Cargo == "Técnico")
            e.PlanSalud = "Estandar";
        else
            e.PlanSalud = "Premium";
        return e;
    });
    // Simular retención IRPF (impuesto) anual
    //Supón 15 % si salario anual< 30k €, 20 % si entre 30k–50k €, 25 % si > 50k €

    // Determinar fecha de revisión de contrato
    // Si antigüedad< 1 año: revisión en 6 meses.Si ≥ 1 año: revisión anual.
    procesos.Add(e =>{
        if(e.AntiguedadAnios < 1){
            e.revisionContrato = 6;
        }else{
            e.revisionContrato = 12;
        }
        return e;
    });


    // 3. Aplicar todos los procesos a todos los empleados
    foreach (var empleado in empleados)
    {
        foreach (var proceso in procesos)
        {
            proceso(empleado); // Modifica el objeto empleado
        }

        // Mostrar resumen tras los procesos
        Console.WriteLine("\n--- Empleado procesado ---");
        Console.WriteLine($"Nombre: {empleado.Nombre}");
        Console.WriteLine($"Cargo: {empleado.Cargo}");
        Console.WriteLine($"Salario anual: {empleado.SalarioAnual} €");
        Console.WriteLine($"Días de vacaciones: {empleado.DiasVacaciones}");
        Console.WriteLine($"Clasificación salarial: {empleado.ClasificacionSalarial}");
        Console.WriteLine($"Bonificación anual: {empleado.Bonificacion:F2} €");
        Console.WriteLine($"Fecha estimada de ascenso: {empleado.FechaEstimacionAscenso.ToShortDateString()}");
    }
}




static void Ejemplo1()
{
    decimal precioOriginal = 2.0m;

    // Aplicar un descuento del 10%
    decimal descuento = 0.10m;
    decimal precioConDescuento = precioOriginal - (precioOriginal * descuento);

    // Aplicar un descuento del 25%
    decimal descuento25 = 0.25m;
    decimal precioConDescuento25 = precioOriginal - (precioOriginal * descuento25);


    // Expresiones lambdas para el cálculo de descuentos

    Func<decimal, decimal> funciondescuento10 = precio => precio - (precio * 0.10m);
    Func<decimal, decimal> funciondescuento25 = precio => precio - (precio * 0.25m);

    // Aplicar los descuentos usando las funciones
    decimal precioConDescuentoLambda = funciondescuento10(precioOriginal);
    decimal precioConDescuento25Lambda = funciondescuento25(precioOriginal);


    Func<decimal, decimal, decimal> calcularDescuento = (precio, porcentaje) =>
    {
        return precio * (1 - porcentaje / 100);
    };

    decimal precioConDescuentoLambda2 = calcularDescuento(precioOriginal, 0.10m);
    decimal precioConDescuento25Lambda2 = calcularDescuento(precioOriginal, 0.25m);
}

static void Ejemplo2()
{
    // Calculadora de operaciones matemáticas
    // Implementar una calculadora que permita sumar, restar, multiplicar y dividir dos números 
    // usando funciones lambda.

    // 1-Crear lambdas para cada operación
    // 2-Ejecutar las operaciones con dos números de tu elección
    // 3-Mostrar los resultados en consola

    Func<decimal, decimal, decimal> suma = (a, b) => a + b;
    Func<decimal, decimal, decimal> resta = (a, b) => a - b;
    Func<decimal, decimal, decimal> multiplicacion = (a, b) => a * b;
    Func<decimal, decimal, decimal> division = (a, b) => b != 0 ? a / b : throw new DivideByZeroException("No se puede dividir entre 0");

    Func<double, double, double> exponencial = (a, b) => Math.Pow(a, b);

    //Ejecución de las operaciones con dos números
    decimal num1 = 10;
    decimal num2 = 5;

    //Operaciones
    Console.WriteLine($"Suma: {suma(num1, num2)}");
    Console.WriteLine($"Resta: {resta(num1, num2)}");
    Console.WriteLine($"Multiplicación: {multiplicacion(num1, num2)}");
    Console.WriteLine($"División: {division(num1, num2)}");
    Console.WriteLine($"Exponencial: {exponencial((double)num1, (double)num2)}");
}