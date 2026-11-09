
using System;

namespace Proyecto1_Clinica
{
    class Program
    {
        static Nodo cabeza = null;

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE CLÍNICA ===");
                Console.WriteLine("1. Registrar nuevo paciente");
                Console.WriteLine("2. Eliminar paciente");
                Console.WriteLine("3. Buscar paciente");
                Console.WriteLine("4. Mostrar lista de pacientes");
                Console.WriteLine("5. Atender paciente");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarPaciente();
                            break;
                        case 2:
                            EliminarPaciente();
                            break;
                        case 3:
                            BuscarPaciente();
                            break;
                        case 4:
                            MostrarPacientes();
                            break;
                        case 5:
                            AtenderPaciente();
                            break;
                        case 6:
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 6);
        }

        static void RegistrarPaciente()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRAR PACIENTE ---");

            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("Edad inválida. Registro cancelado.");
                return;
            }

            Console.Write("Ingrese el diagnóstico: ");
            string diagnostico = Console.ReadLine();

            Paciente nuevoPaciente = new Paciente(nombre, edad, diagnostico);
            Nodo nuevoNodo = new Nodo(nuevoPaciente);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }

            Console.WriteLine("\nPaciente registrado");
        }

        static void EliminarPaciente()
        {
            Console.Clear();
            Console.WriteLine("--- ELIMINAR PACIENTE ---");

            if (cabeza == null)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            if (cabeza.Dato.Nombre == nombre)
            {
                cabeza = cabeza.Siguiente;
                Console.WriteLine("\nPaciente eliminado");
            }
            else
            {
                Nodo actual = cabeza;

                while (actual.Siguiente != null)
                {
                    if (actual.Siguiente.Dato.Nombre == nombre)
                    {
                        actual.Siguiente = actual.Siguiente.Siguiente;
                        Console.WriteLine("\nPaciente eliminado");
                        return;
                    }

                    actual = actual.Siguiente;
                }

                Console.WriteLine("\nPaciente no encontrado.");
            }
        }

        static void BuscarPaciente()
        {
            Console.Clear();
            Console.WriteLine("--- BUSCAR PACIENTE ---");

            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato.Nombre == nombre)
                {
                    Console.WriteLine("\nPaciente encontrado");
                    Console.WriteLine(actual.Dato);
                    return;
                }

                actual = actual.Siguiente;
            }

            Console.WriteLine("\nPaciente no encontrado.");
        }

        static void MostrarPacientes()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE PACIENTES REGISTRADOS ---");

            if (cabeza == null)
            {
                Console.WriteLine("No hay pacientes registrados en el sistema.");
                return;
            }

            Nodo actual = cabeza;
            int contador = 1;
            while (actual != null)
            {
                Console.WriteLine($"{contador}. {actual.Dato}");
                actual = actual.Siguiente;
                contador++;
            }
        }

        static void AtenderPaciente()
        {
            Console.Clear();
            Console.WriteLine("--- ATENDER PACIENTE ---");

            if (cabeza == null)
            {
                Console.WriteLine("No hay pacientes pendientes por atender.");
                return;
            }

            Console.WriteLine("Paciente que será atendido:");
            Console.WriteLine(cabeza.Dato);

            cabeza = cabeza.Siguiente;

            Console.WriteLine("\nPaciente atendido");
        }
    }
}
