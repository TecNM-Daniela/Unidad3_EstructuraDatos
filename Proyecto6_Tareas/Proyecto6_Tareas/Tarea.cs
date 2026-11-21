using System;

namespace Proyecto6_Tareas
{
    public class Tarea
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string Responsable { get; set; }

        public Tarea(int id, string descripcion, string prioridad,
            string fecha, string estado, string responsable)
        {
            this.id = id;
            Descripcion = descripcion;
            Prioridad = prioridad;
            Fecha = fecha;
            Estado = estado;
            Responsable = responsable;
        }

        public override string ToString()
        {
            return $"ID: {id} | Descripción: {Descripcion} | " +
                   $"Prioridad: {Prioridad} | Fecha: {Fecha} | " +
                   $"Estado: {Estado} | Responsable: {Responsable}";
        }
    }
}