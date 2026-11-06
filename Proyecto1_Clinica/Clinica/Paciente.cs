namespace Clinica
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Diagnostico { get; set; }

        // Constructor para inicializar los datos del paciente
        public Paciente(string nombre, int edad, string diagnostico)
        {
            Nombre = nombre;
            Edad = edad;
            Diagnostico = diagnostico;
        }

        // Método para mostrar los datos del paciente de forma ordenada
        public override string ToString()
        {
            return $"Nombre: {Nombre} | Edad: {Edad} | Diagnóstico: {Diagnostico}";
        }
    }
}