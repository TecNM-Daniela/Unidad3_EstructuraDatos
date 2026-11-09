using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_2_Restaurante
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public int Personas { get; set; }
       
        public Cliente(string nombre, int personas)
        {
            Nombre = nombre;
            Personas = personas;
        }
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Personas: {Personas}";
        }
    }
}
