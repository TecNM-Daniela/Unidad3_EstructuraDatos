using Proyecto9_ControlProceso;
using System;

namespace Proyecto9_ControlProceso
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorProcesos gestor = new GestorProcesos();

            int opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=================================");
                Console.WriteLine(" SISTEMA DE CONTROL DE PROCESOS ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Crear proceso");
                Console.WriteLine("2. Eliminar proceso");
                Console.WriteLine("3. Ejecutar proceso");
                Console.WriteLine("4. Bloquear proceso");
                Console.WriteLine("5. Desbloquear proceso");
                Console.WriteLine("6. Mostrar procesos");
                Console.WriteLine("7. Buscar proceso");
                Console.WriteLine("8. Administrar cola");
                Console.WriteLine("9. Salir");
                Console.WriteLine();

                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida.");
                    opcion = 0;
                }

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        gestor.CrearProceso();
                        break;

                    case 2:
                        gestor.EliminarProceso();
                        break;

                    case 3:
                        gestor.EjecutarProceso();
                        break;

                    case 4:
                        gestor.BloquearProceso();
                        break;

                    case 5:
                        gestor.DesbloquearProceso();
                        break;

                    case 6:
                        gestor.MostrarProcesos();
                        break;

                    case 7:
                        gestor.BuscarProceso();
                        break;

                    case 8:
                        gestor.AdministrarCola();
                        break;

                    case 9:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 9)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 9);
        }
    }
}