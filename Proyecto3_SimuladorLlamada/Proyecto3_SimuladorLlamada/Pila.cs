using System;

namespace Proyecto3_SimuladorLlamada
{
    public class Pila
    {
        private Nodo cima;

        // Registrar una llamada
        public void Apilar(Llamada llamada)
        {
            Nodo nuevo = new Nodo(llamada);

            nuevo.Siguiente = cima;
            cima = nuevo;
        }

        // Atender o retirar la ultima llamada
        public Llamada Desapilar()
        {
            if (cima == null)
                return null;

            Llamada llamada = cima.Datos;
            cima = cima.Siguiente;

            return llamada;
        }

        // Recuperar la ultima llamada sin eliminarla
        public Llamada Recuperar()
        {
            if (cima == null)
                return null;

            return cima.Datos;
        }

        // Mostrar las llamadas activas
        public void Mostrar()
        {
            if (cima == null)
            {
                Console.WriteLine("No hay llamadas activas.");
                return;
            }

            Nodo actual = cima;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        // Buscar una llamada por telefono
        public Llamada Buscar(string telefono)
        {
            Nodo actual = cima;

            while (actual != null)
            {
                if (actual.Datos.Telefono == telefono)
                    return actual.Datos;

                actual = actual.Siguiente;
            }

            return null;
        }

        // Eliminar una llamada especifica
        public bool Eliminar(string telefono)
        {
            Nodo actual = cima;
            Nodo anterior = null;

            while (actual != null)
            {
                if (actual.Datos.Telefono == telefono)
                {
                    if (anterior == null)
                        cima = actual.Siguiente;
                    else
                        anterior.Siguiente = actual.Siguiente;

                    return true;
                }

                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }
    }
}
