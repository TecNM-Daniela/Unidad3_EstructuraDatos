using System;

namespace Proyecto8_AtencionBanco
{
    public class ColaPrioridad
    {
        private Nodo? frente;

        private class Nodo
        {
            public Cliente Datos;
            public Nodo? Siguiente;

            public Nodo(Cliente cliente)
            {
                Datos = cliente;
            }
        }

        public void Insertar(Cliente cliente)
        {
            Nodo nuevo = new Nodo(cliente);

            if (frente == null ||
                cliente.Prioridad < frente.Datos.Prioridad)
            {
                nuevo.Siguiente = frente;
                frente = nuevo;
                return;
            }

            Nodo actual = frente;

            while (actual.Siguiente != null &&
                   actual.Siguiente.Datos.Prioridad <= cliente.Prioridad)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
        }

        public Cliente? Atender()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Datos;
            frente = frente.Siguiente;

            return cliente;
        }

        public bool Cancelar(int turno)
        {
            if (frente == null)
                return false;

            if (frente.Datos.Turno == turno)
            {
                frente = frente.Siguiente;
                return true;
            }

            Nodo actual = frente;

            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Datos.Turno == turno)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public int Cantidad()
        {
            int cantidad = 0;
            Nodo? actual = frente;

            while (actual != null)
            {
                cantidad++;
                actual = actual.Siguiente;
            }

            return cantidad;
        }

        public void Mostrar()
        {
            Nodo? actual = frente;

            if (actual == null)
            {
                Console.WriteLine("No hay clientes.");
                return;
            }

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        public void MostrarTiempos(ref int posicion)
        {
            Nodo? actual = frente;

            while (actual != null)
            {
                int tiempo = posicion * 5;

                Console.WriteLine(
                    actual.Datos + " | Tiempo estimado: " + tiempo + " minutos"
                );

                posicion++;
                actual = actual.Siguiente;
            }
        }
    }
}