using System;

namespace Proyecto3_SimuladorLlamada
{
    public class Llamada
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Motivo { get; set; }

        public Llamada(string nombre, string telefono, string motivo)
        {
            Nombre = nombre;
            Telefono = telefono;
            Motivo = motivo;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Telefono: {Telefono}, Motivo: {Motivo}";
        }
    }
}
