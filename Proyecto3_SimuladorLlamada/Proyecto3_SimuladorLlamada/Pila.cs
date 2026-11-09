using System;

namespace Proyecto3_SimuladorLlamada
{
    public class Pila
    {
        public Nodo cima;
        public void Apilar(Llamada llamada)
        {
            Nodo nuevo = new Nodo(llamada);

            nuevo.Siguiente = cima;
            cima = nuevo;
        }
        public Llamada Desapilar()
        {
            if (cima == null)
                return null;

            Llamada llamada = cima.Datos;
            cima = cima.Siguiente;

            return llamada;
        }

        public Llamada Recuperar()
        {
            if (cima == null)
                return null;

            return cima.Datos;
        }
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
