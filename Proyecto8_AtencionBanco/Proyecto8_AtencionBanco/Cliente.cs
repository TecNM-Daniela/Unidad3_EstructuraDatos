namespace Proyecto8_AtencionBanco
{
    public class Cliente
    {
        public int Turno { get; set; }
        public string Nombre { get; set; }
        public int Prioridad { get; set; }
        public string TipoCliente { get; set; }

        public Cliente(int turno, string nombre, int prioridad, string tipoCliente)
        {
            Turno = turno;
            Nombre = nombre;
            Prioridad = prioridad;
            TipoCliente = tipoCliente;
        }

        public override string ToString()
        {
            return $"Turno {Turno} | Nombre: {Nombre} | Tipo: {TipoCliente} | Prioridad: {Prioridad}";
        }
    }
}