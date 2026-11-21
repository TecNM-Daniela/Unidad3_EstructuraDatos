using System;

namespace Proyecto6_Tareas
{
    internal class Program
    {
        static ListaDoble lista = new ListaDoble();

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== ADMINISTRADOR DE TAREAS =====");
                Console.WriteLine("1. Agregar tarea.");
                Console.WriteLine("2. Eliminar tarea.");
                Console.WriteLine("3. Buscar tarea.");
                Console.WriteLine("4. Modificar tarea.");
                Console.WriteLine("5. Marcar como terminada.");
                Console.WriteLine("6. Mostrar todas las tareas.");
                Console.WriteLine("7. Mostrar tareas pendientes.");
                Console.WriteLine("8. Mostrar tareas terminadas.");
                Console.WriteLine("9. Ordenar tareas.");
                Console.WriteLine("10. Recorrer lista hacia adelante.");
                Console.WriteLine("11. Recorrer lista hacia atrás.");
                Console.WriteLine("0. Salir.");
                Console.Write("Selecciona una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        {
                            Console.Write("ID: ");
                            int id = int.Parse(Console.ReadLine());

                            if (lista.Buscar(id) != null)
                            {
                                Console.WriteLine("Ese ID ya existe.");
                                break;
                            }

                            Console.Write("Descripción: ");
                            string descripcion = Console.ReadLine();

                            Console.Write("Prioridad (Alta, Media, Baja): ");
                            string prioridad = Console.ReadLine();

                            Console.Write("Fecha: ");
                            string fecha = Console.ReadLine();

                            Console.Write("Responsable: ");
                            string responsable = Console.ReadLine();

                            lista.Insertar(new Tarea(id, descripcion,
                                prioridad, fecha, "Pendiente", responsable));

                            Console.WriteLine("Tarea agregada correctamente.");
                            break;
                        }

                    case 2:
                        {
                            Console.Write("ID de la tarea a eliminar: ");
                            int id = int.Parse(Console.ReadLine());

                            if (lista.Eliminar(id))
                                Console.WriteLine("Tarea eliminada.");
                            else
                                Console.WriteLine("Tarea no encontrada.");

                            break;
                        }

                    case 3:
                        {
                            Console.Write("ID de la tarea a buscar: ");
                            int id = int.Parse(Console.ReadLine());

                            Tarea tarea = lista.Buscar(id);

                            if (tarea != null)
                                Console.WriteLine(tarea);
                            else
                                Console.WriteLine("Tarea no encontrada.");

                            break;
                        }

                    case 4:
                        {
                            Console.Write("ID de la tarea a modificar: ");
                            int id = int.Parse(Console.ReadLine());

                            Tarea tarea = lista.Buscar(id);

                            if (tarea != null)
                            {
                                Console.Write("Nueva descripción: ");
                                tarea.Descripcion = Console.ReadLine();

                                Console.Write("Nueva prioridad: ");
                                tarea.Prioridad = Console.ReadLine();

                                Console.Write("Nueva fecha: ");
                                tarea.Fecha = Console.ReadLine();

                                Console.Write("Nuevo responsable: ");
                                tarea.Responsable = Console.ReadLine();

                                Console.WriteLine("Tarea modificada correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Tarea no encontrada.");
                            }

                            break;
                        }

                    case 5:
                        {
                            Console.Write("ID de la tarea terminada: ");
                            int id = int.Parse(Console.ReadLine());

                            if (lista.MarcarTerminada(id))
                                Console.WriteLine("Tarea marcada como terminada.");
                            else
                                Console.WriteLine("Tarea no encontrada.");

                            break;
                        }

                    case 6:
                        lista.Mostrar();
                        break;

                    case 7:
                        lista.MostrarPendientes();
                        break;

                    case 8:
                        lista.MostrarTerminadas();
                        break;

                    case 9:
                        lista.Ordenar();
                        Console.WriteLine("Tareas ordenadas por prioridad.");
                        break;

                    case 10:
                        lista.MostrarAdelante();
                        break;

                    case 11:
                        lista.MostrarAtras();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}