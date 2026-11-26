using System;
using System.Collections.Generic;

namespace Proyecto_10_Tienda_en_Linea
{
    public class HistorialOperaciones
    {
        private Stack<string> historial = new Stack<string>();

        public void Agregar(string operacion)
        {
            historial.Push(operacion);
        }

        public void Mostrar()
        {
            if (historial.Count == 0)
            {
                Console.WriteLine("No hay operaciones registradas.");
                return;
            }

            Console.WriteLine("\n--- HISTORIAL DE OPERACIONES ---");

            foreach (string op in historial)
            {
                Console.WriteLine(op);
            }
        }
    }
}
