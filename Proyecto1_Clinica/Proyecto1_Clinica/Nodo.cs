
using System;

namespace Proyecto1_Clinica
{
    public class Nodo
    {
        public Paciente Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Paciente paciente)
        {
            Dato = paciente;
            Siguiente = null;
        }
    }
}

