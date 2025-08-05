// See https://aka.ms/new-console-template for more information
using EjemplosLinq;
using System.Diagnostics;
using System.Diagnostics.Metrics;

Console.WriteLine("Hello, World!");

//Ejemplo1();

//Ejemplo2();

Ejemplo3();


static void Ejemplo3()
{

    // 1. Lista de empleados
    List<Empleado> empleados = new List<Empleado>
        {
            new Empleado { Nombre = "Ana", Cargo = "Administrativa", SalarioMensual = 1800m, AntiguedadAnios = 3 },
            new Empleado { Nombre = "Luis", Cargo = "Técnico", SalarioMensual = 2200m, AntiguedadAnios = 5 },
            new Empleado { Nombre = "Marta", Cargo = "Jefa de Proyecto", SalarioMensual = 3500m, AntiguedadAnios = 10 }
        };

    // 2. Lista de procesos FUNC que modifican al empleado y lo devuelven
    List<Func<Empleado, Empleado>> procesos = new List<Func<Empleado, Empleado>>();

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