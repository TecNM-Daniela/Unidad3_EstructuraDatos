using System;

namespace Clinica
{
    class Program
    {
        // Referencia al inicio de la lista enlazada
        static Nodo cabeza = null;

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE CLÍNICA ===");
                Console.WriteLine("1. Registrar nuevo paciente");
                Console.WriteLine("2. Mostrar lista de pacientes");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        //pidirDatos:
                        case 1:
                            RegistrarPaciente();
                            break;
                        case 2:
                            MostrarPacientes();
                            break;
                        case 3:
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

                if (opcion != 3)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 3);
        }

        // Método para agregar un paciente al final de la lista
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

            // Si la lista está vacía, el nuevo nodo es la cabeza
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                // Si no está vacía, recorremos hasta el final
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }

            Console.WriteLine("\n¡Paciente registrado exitosamente!");
        }

        // Método para recorrer e imprimir todos los pacientes de la lista
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
    }
}