using Proyecto3_SimuladorLlamada;
using System;

namespace Proyecto3_SimuladorLlamada
{
    internal class Program
    {
        static Pila llamadas = new Pila();

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=== SIMULADOR DE LLAMADAS ===");
                Console.WriteLine("1. Registrar llamada");
                Console.WriteLine("2. Atender llamada");
                Console.WriteLine("3. Finalizar llamada");
                Console.WriteLine("4. Mostrar llamadas activas");
                Console.WriteLine("5. Recuperar ultima llamada");
                Console.WriteLine("6. Buscar llamada");
                Console.WriteLine("7. Eliminar llamada");
                Console.WriteLine("0. Salir");

                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Registrar();
                        break;

                    case 2:
                        Atender();
                        break;

                    case 3:
                        Finalizar();
                        break;

                    case 4:
                        Mostrar();
                        break;

                    case 5:
                        Recuperar();
                        break;

                    case 6:
                        Buscar();
                        break;

                    case 7:
                        Eliminar();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }

        // Registrar una llamada
        static void Registrar()
        {
            Console.Clear();

            Console.Write("Ingrese el nombre del contacto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el numero telefonico: ");
            string telefono = Console.ReadLine();

            Console.Write("Ingrese el motivo de la llamada: ");
            string motivo = Console.ReadLine();

            llamadas.Apilar(new Llamada(nombre, telefono, motivo));

            Console.WriteLine("\nLlamada registrada correctamente.");
            Console.ReadKey();
        }

        // Atender la ultima llamada
        static void Atender()
        {
            Console.Clear();

            Llamada llamada = llamadas.Desapilar();

            if (llamada == null)
                Console.WriteLine("No hay llamadas para atender.");
            else
                Console.WriteLine($"Llamada atendida: {llamada}");

            Console.ReadKey();
        }

        // Finalizar la llamada actual
        static void Finalizar()
        {
            Console.Clear();

            Llamada llamada = llamadas.Desapilar();

            if (llamada == null)
                Console.WriteLine("No hay llamadas activas.");
            else
                Console.WriteLine($"Llamada finalizada: {llamada}");

            Console.ReadKey();
        }

        // Mostrar todas las llamadas
        static void Mostrar()
        {
            Console.Clear();

            Console.WriteLine("=== LLAMADAS ACTIVAS ===");

            llamadas.Mostrar();

            Console.ReadKey();
        }

        // Recuperar la ultima llamada sin eliminarla
        static void Recuperar()
        {
            Console.Clear();

            Llamada llamada = llamadas.Recuperar();

            if (llamada == null)
                Console.WriteLine("No hay llamadas registradas.");
            else
                Console.WriteLine($"Ultima llamada registrada:\n{llamada}");

            Console.ReadKey();
        }

        // Buscar una llamada
        static void Buscar()
        {
            Console.Clear();

            Console.Write("Ingrese el numero telefonico a buscar: ");
            string telefono = Console.ReadLine();

            Llamada llamada = llamadas.Buscar(telefono);

            if (llamada == null)
                Console.WriteLine("No se encontro la llamada.");
            else
                Console.WriteLine($"Llamada encontrada:\n{llamada}");

            Console.ReadKey();
        }

        // Eliminar una llamada
        static void Eliminar()
        {
            Console.Clear();

            Console.Write("Ingrese el numero telefonico de la llamada a eliminar: ");
            string telefono = Console.ReadLine();

            bool eliminado = llamadas.Eliminar(telefono);

            if (eliminado)
                Console.WriteLine("Llamada eliminada correctamente.");
            else
                Console.WriteLine("No se encontro la llamada.");

            Console.ReadKey();
        }
    }
}