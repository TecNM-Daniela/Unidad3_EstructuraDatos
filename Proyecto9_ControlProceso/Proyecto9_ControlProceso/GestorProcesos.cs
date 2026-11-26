using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Proyecto9_ControlProceso
{
    public class GestorProcesos
    {
        private LinkedList<Proceso> listaProcesos;
        private Queue<Proceso> colaListos;
        private Queue<Proceso> colaCircular;

        private int siguientePID;
        private const int QUANTUM = 3;

        public GestorProcesos()
        {
            listaProcesos = new LinkedList<Proceso>();
            colaListos = new Queue<Proceso>();
            colaCircular = new Queue<Proceso>();

            siguientePID = 1;
        }

        public void CrearProceso()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "Sin nombre";

            Console.Write("Prioridad: ");

            if (!int.TryParse(Console.ReadLine(), out int prioridad))
            {
                Console.WriteLine("Prioridad inválida.");
                return;
            }

            Console.Write("Tiempo de ejecución: ");

            if (!int.TryParse(Console.ReadLine(), out int tiempo) || tiempo <= 0)
            {
                Console.WriteLine("Tiempo de ejecución inválido.");
                return;
            }

            Proceso nuevo = new Proceso(
                siguientePID,
                nombre,
                prioridad,
                tiempo
            );

            siguientePID++;

            nuevo.Estado = Estados.LISTO;

            listaProcesos.AddLast(nuevo);

            colaListos.Enqueue(nuevo);
            colaCircular.Enqueue(nuevo);

            Console.WriteLine("\nProceso creado correctamente.");
            Console.WriteLine(nuevo);
        }

        public void EliminarProceso()
        {
            Console.Write("PID a eliminar: ");

            if (!int.TryParse(Console.ReadLine(), out int pid))
            {
                Console.WriteLine("PID inválido.");
                return;
            }

            Proceso proceso = BuscarPID(pid);

            if (proceso == null)
            {
                Console.WriteLine("Proceso no encontrado.");
                return;
            }

            listaProcesos.Remove(proceso);

            ActualizarColas();

            Console.WriteLine("Proceso eliminado.");
        }

        public void EjecutarProceso()
        {
            if (colaCircular.Count == 0)
            {
                Console.WriteLine("No hay procesos listos.");
                return;
            }

            Proceso actual = colaCircular.Dequeue();

            actual.Estado = Estados.EJECUTANDO;

            Console.WriteLine("\nEjecutando proceso:");
            Console.WriteLine(actual);

            if (actual.TiempoEjecucion <= QUANTUM)
            {
                actual.TiempoEjecucion = 0;
                actual.Estado = Estados.TERMINADO;

                Console.WriteLine("\nProceso terminado.");
            }
            else
            {
                actual.TiempoEjecucion -= QUANTUM;

                actual.Estado = Estados.LISTO;

                colaCircular.Enqueue(actual);

                Console.WriteLine("\nEl proceso no ha terminado.");
                Console.WriteLine("Tiempo restante: " + actual.TiempoEjecucion);
                Console.WriteLine("El proceso regresa al final de la cola.");
            }

            ActualizarColaListos();
        }

        public void BloquearProceso()
        {
            Console.Write("PID a bloquear: ");

            if (!int.TryParse(Console.ReadLine(), out int pid))
            {
                Console.WriteLine("PID inválido.");
                return;
            }

            Proceso proceso = BuscarPID(pid);

            if (proceso == null)
            {
                Console.WriteLine("Proceso no encontrado.");
                return;
            }

            if (proceso.Estado != Estados.LISTO)
            {
                Console.WriteLine("Solo se pueden bloquear procesos listos.");
                return;
            }

            proceso.Estado = Estados.BLOQUEADO;

            ActualizarColas();

            Console.WriteLine("Proceso bloqueado correctamente.");
        }

        public void DesbloquearProceso()
        {
            Console.Write("PID a desbloquear: ");

            if (!int.TryParse(Console.ReadLine(), out int pid))
            {
                Console.WriteLine("PID inválido.");
                return;
            }

            Proceso proceso = BuscarPID(pid);

            if (proceso == null)
            {
                Console.WriteLine("Proceso no encontrado.");
                return;
            }

            if (proceso.Estado != Estados.BLOQUEADO)
            {
                Console.WriteLine("El proceso no se encuentra bloqueado.");
                return;
            }

            proceso.Estado = Estados.LISTO;

            colaListos.Enqueue(proceso);
            colaCircular.Enqueue(proceso);

            Console.WriteLine("Proceso desbloqueado correctamente.");
        }

        public void MostrarProcesos()
        {
            if (listaProcesos.Count == 0)
            {
                Console.WriteLine("No existen procesos.");
                return;
            }

            Console.WriteLine("\n--- LISTA DE PROCESOS ---\n");

            foreach (Proceso proceso in listaProcesos)
            {
                Console.WriteLine(proceso);
            }
        }

        public void BuscarProceso()
        {
            Console.Write("PID a buscar: ");

            if (!int.TryParse(Console.ReadLine(), out int pid))
            {
                Console.WriteLine("PID inválido.");
                return;
            }

            Proceso proceso = BuscarPID(pid);

            if (proceso == null)
            {
                Console.WriteLine("Proceso no encontrado.");
                return;
            }

            Console.WriteLine("\nProceso encontrado:");
            Console.WriteLine(proceso);
        }

        public void AdministrarCola()
        {
            Console.WriteLine("\n--- COLA DE PROCESOS LISTOS ---");

            if (colaListos.Count == 0)
            {
                Console.WriteLine("No hay procesos listos.");
            }
            else
            {
                foreach (Proceso proceso in colaListos)
                {
                    Console.WriteLine(
                        "P" + proceso.PID + " - " + proceso.Nombre
                    );
                }
            }

            Console.WriteLine("\n--- COLA CIRCULAR (ROUND ROBIN) ---");

            if (colaCircular.Count == 0)
            {
                Console.WriteLine("No hay procesos en la cola circular.");
            }
            else
            {
                foreach (Proceso proceso in colaCircular)
                {
                    Console.WriteLine(
                        "P" + proceso.PID +
                        " - " + proceso.Nombre +
                        " - Tiempo: " + proceso.TiempoEjecucion
                    );
                }
            }

            Console.WriteLine("\nTotal de procesos: " + listaProcesos.Count);
            Console.WriteLine("Procesos listos: " + colaListos.Count);
        }

        private Proceso BuscarPID(int pid)
        {
            return listaProcesos.FirstOrDefault(
                p => p.PID == pid
            );
        }

        private void ActualizarColas()
        {
            colaListos.Clear();
            colaCircular.Clear();

            foreach (Proceso proceso in listaProcesos)
            {
                if (proceso.Estado == Estados.LISTO)
                {
                    colaListos.Enqueue(proceso);
                    colaCircular.Enqueue(proceso);
                }
            }
        }

        private void ActualizarColaListos()
        {
            colaListos.Clear();

            foreach (Proceso proceso in colaCircular)
            {
                colaListos.Enqueue(proceso);
            }
        }
    }
}