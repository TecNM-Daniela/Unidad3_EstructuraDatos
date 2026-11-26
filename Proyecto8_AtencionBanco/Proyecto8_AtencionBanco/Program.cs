using Proyecto8_AtencionBanco;
using System;

namespace Proyecto8_AtencionBanco
{
    internal class Program
    {
        static void Main()
        {
            ColaPrioridad colaPrioridad = new ColaPrioridad();
            Cola colaNormal = new Cola();
            ColaCircular atendidos = new ColaCircular(20);

            int siguienteTurno = 1;
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== SISTEMA DE ATENCIÓN AL BANCO ===");
                Console.WriteLine("1. Generar turno");
                Console.WriteLine("2. Atender siguiente cliente");
                Console.WriteLine("3. Cancelar turno");
                Console.WriteLine("4. Mostrar clientes en espera");
                Console.WriteLine("5. Mostrar clientes atendidos");
                Console.WriteLine("6. Mostrar tiempo estimado");
                Console.WriteLine("7. Mostrar número de clientes en espera");
                Console.WriteLine("8. Salir");
                Console.Write("Selecciona una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del cliente: ");
                        string? nombre = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nombre))
                        {
                            nombre = "Sin nombre";
                        }

                        Console.WriteLine("\nTipo de cliente:");
                        Console.WriteLine("1. Cliente normal");
                        Console.WriteLine("2. Cliente preferente");
                        Console.WriteLine("3. Adulto mayor");
                        Console.WriteLine("4. Persona con prioridad");
                        Console.Write("Selecciona el tipo: ");

                        if (int.TryParse(Console.ReadLine(), out int tipo) &&
                            tipo >= 1 && tipo <= 4)
                        {
                            int prioridad;
                            string tipoCliente;

                            switch (tipo)
                            {
                                case 1:
                                    prioridad = 4;
                                    tipoCliente = "Normal";
                                    break;

                                case 2:
                                    prioridad = 3;
                                    tipoCliente = "Preferente";
                                    break;

                                case 3:
                                    prioridad = 2;
                                    tipoCliente = "Adulto mayor";
                                    break;

                                default:
                                    prioridad = 1;
                                    tipoCliente = "Persona con prioridad";
                                    break;
                            }

                            Cliente nuevoCliente = new Cliente(
                                siguienteTurno++,
                                nombre.Trim(),
                                prioridad,
                                tipoCliente
                            );

                            if (prioridad == 4)
                            {
                                colaNormal.Insertar(nuevoCliente);
                            }
                            else
                            {
                                colaPrioridad.Insertar(nuevoCliente);
                            }

                            Console.WriteLine("\nTurno generado correctamente.");
                            Console.WriteLine(nuevoCliente);
                        }
                        else
                        {
                            Console.WriteLine("Tipo de cliente inválido.");
                        }
                        break;

                    case "2":
                        Cliente? atendido = null;

                        if (!colaPrioridad.EstaVacia())
                        {
                            atendido = colaPrioridad.Atender();
                        }
                        else
                        {
                            atendido = colaNormal.Atender();
                        }

                        if (atendido != null)
                        {
                            atendidos.Insertar(atendido);
                            Console.WriteLine("\nAtendiendo a:");
                            Console.WriteLine(atendido);
                        }
                        else
                        {
                            Console.WriteLine("No hay clientes en espera.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingresa el número de turno que deseas cancelar: ");

                        if (int.TryParse(Console.ReadLine(), out int turno))
                        {
                            bool cancelado = colaPrioridad.Cancelar(turno);

                            if (!cancelado)
                            {
                                cancelado = colaNormal.Cancelar(turno);
                            }

                            if (cancelado)
                            {
                                Console.WriteLine("Turno cancelado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró el turno.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número de turno inválido.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\n--- CLIENTES EN ESPERA ---");

                        if (colaPrioridad.EstaVacia() && colaNormal.EstaVacia())
                        {
                            Console.WriteLine("No hay clientes en espera.");
                        }
                        else
                        {
                            Console.WriteLine("\nClientes con prioridad:");
                            colaPrioridad.Mostrar();

                            Console.WriteLine("\nClientes normales:");
                            colaNormal.Mostrar();
                        }
                        break;

                    case "5":
                        Console.WriteLine("\n--- CLIENTES ATENDIDOS ---");
                        atendidos.Mostrar();
                        break;

                    case "6":
                        int especiales = colaPrioridad.Cantidad();
                        int normales = colaNormal.Cantidad();
                        int posicion = 0;

                        Console.WriteLine("\n--- TIEMPO ESTIMADO DE ESPERA ---");

                        if (especiales + normales == 0)
                        {
                            Console.WriteLine("No hay clientes esperando.");
                        }
                        else
                        {
                            Console.WriteLine("\nClientes con prioridad:");
                            colaPrioridad.MostrarTiempos(ref posicion);

                            Console.WriteLine("\nClientes normales:");
                            colaNormal.MostrarTiempos(ref posicion);

                            Console.WriteLine("\nTiempo aproximado por cliente: 5 minutos.");
                        }
                        break;

                    case "7":
                        int total = colaPrioridad.Cantidad() +
                                    colaNormal.Cantidad();

                        Console.WriteLine("\nNúmero de clientes en espera: " + total);
                        break;

                    case "8":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}