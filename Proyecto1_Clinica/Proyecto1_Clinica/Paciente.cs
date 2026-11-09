
using System;

namespace Proyecto1_Clinica
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Diagnostico { get; set; }

        public Paciente(string nombre, int edad, string diagnostico)
        {
            Nombre = nombre;
            Edad = edad;
            Diagnostico = diagnostico;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} | Edad: {Edad} | Diagnóstico: {Diagnostico}";
        }
    }
}
