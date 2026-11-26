namespace Proyecto9_ControlProceso
{
    public class Proceso
    {
        public int PID { get; set; }
        public string Nombre { get; set; }
        public int Prioridad { get; set; }
        public string Estado { get; set; }
        public int TiempoEjecucion { get; set; }

        public Proceso(int pid, string nombre, int prioridad, int tiempo)
        {
            PID = pid;
            Nombre = nombre;
            Prioridad = prioridad;
            TiempoEjecucion = tiempo;
            Estado = Estados.NUEVO;
        }

        public override string ToString()
        {
            return
                "PID: " + PID +
                " | Nombre: " + Nombre +
                " | Prioridad: " + Prioridad +
                " | Estado: " + Estado +
                " | Tiempo: " + TiempoEjecucion;
        }
    }
}