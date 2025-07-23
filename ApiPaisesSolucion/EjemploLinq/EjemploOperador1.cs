
using EjemploLINQ;

internal class EjemploOperador1
{
    public EjemploOperador1()
    {
    }

    internal void Ejecutar()
    {
        // Lista de empleados
        IEnumerable<Empleado> empleados = new List<Empleado>()
         {

             new Empleado
             {
                 Nombre = "Jose",
                 Apellidos = "Hernandez",
                 Ciudad = "Madrid",
                 Telefono = "123456789",
                 Edad = 25,
                 Departamento = Departamento.RH
             },
             new Empleado
             {
                 Nombre = "Luis",
                 Apellidos = "Lopez",
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

        

        // select teléfono from empleados where Apellidos like "%a%"


        foreach (var empleado in empleados)
        {
            if (empleado.Ciudad == "Madrid" && empleado.Apellidos.Contains("a"))
            {

            }
        }

        // Sintaxis de consulta
        var resultado = from empleado in empleados
                        where empleado.Ciudad == "Madrid" && empleado.Apellidos.Contains("a") 
                        orderby empleado.Nombre
                        select empleado;

        

        var desarrollo = from empleado in resultado
                         where empleado.Departamento == Departamento.Desarrollo
                         select empleado;

        var resultadoLista = desarrollo.ToList();



        // Sintaxis de metodos
        IEnumerable<string> restultado2 =  empleados.Where(e => e.Ciudad == "Madrid" && e.Apellidos.Contains('e') && e.Departamento == Departamento.Desarrollo).OrderBy(e => e.Nombre).Select(e => e.Telefono);
        List<string> resultadoLista2 = restultado2.ToList();











    }
}