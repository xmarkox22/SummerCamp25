using System;
using System.Collections.Generic;
using System.Threading;

namespace RegistroEdificiosApp
{
    public class Program
    {
        public static void Main()
        {
            int leftMargin = 10;
            MostrarLogotipoEmpresa(leftMargin);
            MostrarTituloAnimado("Fondos QuebrantaPrecios", leftMargin);

            // Crear lista inicial de edificios
            var edificios = new List<Edificio>
            {
                new Edificio { Direccion = "Calle Mayor 1", NumeroDePisos = 5, TieneAscensor = true },
                new Edificio { Direccion = "Avenida Central 23", NumeroDePisos = 3, TieneAscensor = false },
                new Edificio { Direccion = "Plaza España 10", NumeroDePisos = 8, TieneAscensor = true }
            };

            // Mostrar edificios existentes
            MostrarListaDeEdificios(edificios);

            // Iniciar formulario de registro
            Console.WriteLine("\n=== Registrar Nuevo Edificio ===");

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            int numeroDePisos = 0;
            while (true)
            {
                Console.Write("Número de pisos: ");
                if (int.TryParse(Console.ReadLine(), out numeroDePisos) && numeroDePisos >= 0)
                    break;

                Console.WriteLine("⚠️  Por favor, introduce un número válido mayor o igual a 0.");
            }

            bool tieneAscensor = false;
            while (true)
            {
                Console.Write("¿Tiene ascensor? (s/n): ");
                string respuesta = Console.ReadLine()?.Trim().ToLower();
                if (respuesta == "s")
                {
                    tieneAscensor = true;
                    break;
                }
                else if (respuesta == "n")
                {
                    tieneAscensor = false;
                    break;
                }
                else
                {
                    Console.WriteLine("⚠️  Respuesta no válida. Escribe 's' para sí o 'n' para no.");
                }
            }

            // Crear nuevo edificio y agregarlo a la lista
            var nuevoEdificio = new Edificio
            {
                Direccion = direccion,
                NumeroDePisos = numeroDePisos,
                TieneAscensor = tieneAscensor
            };

            edificios.Add(nuevoEdificio);

            Console.WriteLine("\n✅ Edificio registrado correctamente.");

            // Volver a mostrar la lista
            MostrarListaDeEdificios(edificios);
        }

        public static void MostrarListaDeEdificios(List<Edificio> edificios)
        {
            Console.WriteLine("\n📋 Lista de Edificios:");
            foreach (var edificio in edificios)
            {
                Console.WriteLine($"Dirección: {edificio.Direccion}, Pisos: {edificio.NumeroDePisos}, Ascensor: {(edificio.TieneAscensor ? "Sí" : "No")}");
            }
        }

        public static void MostrarTituloAnimado(string titulo, int leftMargin)
        {
            var colores = new[]
            {
                ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green,
                ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.Magenta
            };
            int colorIndex = 0;
            Console.Write(new string(' ', leftMargin));
            foreach (char c in titulo)
            {
                Console.ForegroundColor = colores[colorIndex % colores.Length];
                Console.Write(c);
                colorIndex++;
                Thread.Sleep(80); // Animación: pausa breve entre letras
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void MostrarLogotipoEmpresa(int leftMargin)
        {
            string[] logo = new[]
            {
                "  ______   ____   ____  ",
                " |  ____| |  _ \\ |  __| ",
                " | |__    | |_) )| |__  ",
                " |  __|   |  __/ |  __| ",
                " | |____  | |    | |___ ",
                " |______| |_|    |_____|",
                "                        ",
                "   F Q P                "
            };
            foreach (var line in logo)
            {
                Console.WriteLine(new string(' ', leftMargin) + line);
            }
        }
    }

    public class Edificio
    {
        public string Direccion { get; set; }
        public int NumeroDePisos { get; set; }
        public bool TieneAscensor { get; set; }
    }
}
