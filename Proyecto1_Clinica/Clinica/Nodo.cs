namespace Clinica
{
    public class Nodo
    {
        public Paciente Dato { get; set; }
        public Nodo Siguiente { get; set; }

        // Constructor del nodo
        public Nodo(Paciente paciente)
        {
            Dato = paciente;
            Siguiente = null;
        }
    }
}