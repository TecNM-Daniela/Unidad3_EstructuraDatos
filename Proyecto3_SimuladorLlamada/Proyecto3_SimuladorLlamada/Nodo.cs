using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto3_SimuladorLlamada
{
    public class Nodo
    {
        public Llamada Datos;
        public Nodo Siguiente;

        public Nodo(Llamada llamada)
        {
            Datos = llamada;
            Siguiente = null;
        }
    }
}
