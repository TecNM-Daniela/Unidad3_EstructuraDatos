using System;

namespace Proyecto6_Tareas
{
    public class ListaDoble
    {
        private Nodo inicio;

        private class Nodo
        {
            public Tarea Datos;
            public Nodo Anterior;
            public Nodo Siguiente;

            public Nodo(Tarea tarea)
            {
                Datos = tarea;
            }
        }

        // Insertar una tarea al final
        public void Insertar(Tarea tarea)
        {
            Nodo nuevo = new Nodo(tarea);

            if (inicio == null)
            {
                inicio = nuevo;
                return;
            }

            Nodo actual = inicio;

            while (actual.Siguiente != null)
                actual = actual.Siguiente;

            actual.Siguiente = nuevo;
            nuevo.Anterior = actual;
        }

        // Buscar una tarea por su ID
        public Tarea Buscar(int id)
        {
            Nodo actual = inicio;

            while (actual != null)
            {
                if (actual.Datos.id == id)
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        // Eliminar una tarea
        public bool Eliminar(int id)
        {
            Nodo actual = inicio;

            while (actual != null)
            {
                if (actual.Datos.id == id)
                {
                    if (actual == inicio)
                        inicio = actual.Siguiente;
                    else
                        actual.Anterior.Siguiente = actual.Siguiente;

                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;

                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        // Mostrar todas las tareas
        public void Mostrar()
        {
            if (inicio == null)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            Nodo actual = inicio;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        // Marcar una tarea como terminada
        public bool MarcarTerminada(int id)
        {
            Tarea tarea = Buscar(id);

            if (tarea == null)
                return false;

            tarea.Estado = "Terminada";
            return true;
        }

        // Mostrar solamente las tareas pendientes
        public void MostrarPendientes()
        {
            Nodo actual = inicio;
            bool encontrado = false;

            while (actual != null)
            {
                if (actual.Datos.Estado == "Pendiente")
                {
                    Console.WriteLine(actual.Datos);
                    encontrado = true;
                }

                actual = actual.Siguiente;
            }

            if (!encontrado)
                Console.WriteLine("No hay tareas pendientes.");
        }

        // Mostrar solamente las tareas terminadas
        public void MostrarTerminadas()
        {
            Nodo actual = inicio;
            bool encontrado = false;

            while (actual != null)
            {
                if (actual.Datos.Estado == "Terminada")
                {
                    Console.WriteLine(actual.Datos);
                    encontrado = true;
                }

                actual = actual.Siguiente;
            }

            if (!encontrado)
                Console.WriteLine("No hay tareas terminadas.");
        }

        // Ordenar tareas por prioridad
        public void Ordenar()
        {
            if (inicio == null)
                return;

            Nodo actual;
            bool cambio;

            do
            {
                cambio = false;
                actual = inicio;

                while (actual.Siguiente != null)
                {
                    if (ObtenerPrioridad(actual.Datos.Prioridad) >
                        ObtenerPrioridad(actual.Siguiente.Datos.Prioridad))
                    {
                        Tarea auxiliar = actual.Datos;
                        actual.Datos = actual.Siguiente.Datos;
                        actual.Siguiente.Datos = auxiliar;

                        cambio = true;
                    }

                    actual = actual.Siguiente;
                }

            } while (cambio);
        }

        // Asignar un valor para ordenar las prioridades
        private int ObtenerPrioridad(string prioridad)
        {
            if (prioridad.Equals("Alta", StringComparison.OrdinalIgnoreCase))
                return 1;

            if (prioridad.Equals("Media", StringComparison.OrdinalIgnoreCase))
                return 2;

            if (prioridad.Equals("Baja", StringComparison.OrdinalIgnoreCase))
                return 3;

            return 4;
        }

        // Recorrer la lista desde el inicio hasta el final
        public void MostrarAdelante()
        {
            if (inicio == null)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            Nodo actual = inicio;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        // Recorrer la lista desde el final hasta el inicio
        public void MostrarAtras()
        {
            if (inicio == null)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            Nodo actual = inicio;

            while (actual.Siguiente != null)
                actual = actual.Siguiente;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Anterior;
            }
        }
    }
}