using System;
namespace Proyecto_2_Restaurante
{
    internal class Program
    {
        static Cola espera = new Cola();
        static void Main()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Restaurante ===");
                Console.WriteLine("1. Agregar cliente");
                Console.WriteLine("2. Asignar mesa");
                Console.WriteLine("3. Mostrar cola");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Agregar();
                        break;
                    case 2:
                        AsignarMesa();
                        break;
                    case 3:
                        espera.Mostrar();
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0) ;
        }
        static void Agregar()
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el número de personas: ");
            int personas = int.Parse(Console.ReadLine());
            espera.Encolar(new Cliente(nombre, personas));
            Console.WriteLine("Cliente agregado a la cola.");
            Console.ReadKey();
        }
        static void AsignarMesa()
        {
           Cliente cliente = espera.Desencolar();
            if(cliente != null)
                Console.WriteLine("No hay clientes.");
            else
                Console.WriteLine($"Mesa asignada al cliente: {cliente}");
            Console.ReadKey();
        }
    }
}
