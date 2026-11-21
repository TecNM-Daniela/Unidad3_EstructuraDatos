using System;

namespace Proyecto7_Musica
{
    public class Cancion
    {
        public string Nombre { get; set; }
        public string Artista { get; set; }

        public Cancion(string nombre, string artista)
        {
            Nombre = nombre;
            Artista = artista;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Artista}";
        }
    }
}