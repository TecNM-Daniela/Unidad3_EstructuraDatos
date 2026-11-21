using System;

namespace Proyecto7_Musica
{
    public class ListaCircular
    {
        private Nodo primera;
        private Nodo actual;

        private string nombrePlaylist = "Mi Playlist";
        private bool reproduciendo = false;
        private bool circular = true;

        private class Nodo
        {
            public Cancion Datos;
            public Nodo Siguiente;
            public Nodo Anterior;

            public Nodo(Cancion cancion)
            {
                Datos = cancion;
            }
        }

        // Agregar una canción a la lista
        public void Agregar(Cancion cancion)
        {
            Nodo nuevo = new Nodo(cancion);

            if (primera == null)
            {
                primera = nuevo;
                actual = nuevo;

                nuevo.Siguiente = nuevo;
                nuevo.Anterior = nuevo;
            }
            else
            {
                Nodo ultimo = primera.Anterior;

                ultimo.Siguiente = nuevo;
                nuevo.Anterior = ultimo;

                nuevo.Siguiente = primera;
                primera.Anterior = nuevo;
            }

            Console.WriteLine("Canción agregada correctamente.");
        }

        // Eliminar una canción por su nombre
        public bool Eliminar(string nombre)
        {
            if (primera == null)
                return false;

            Nodo auxiliar = primera;

            do
            {
                if (auxiliar.Datos.Nombre.Equals(nombre,
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (auxiliar.Siguiente == auxiliar)
                    {
                        primera = null;
                        actual = null;
                    }
                    else
                    {
                        auxiliar.Anterior.Siguiente = auxiliar.Siguiente;
                        auxiliar.Siguiente.Anterior = auxiliar.Anterior;

                        if (auxiliar == primera)
                            primera = auxiliar.Siguiente;

                        if (auxiliar == actual)
                            actual = auxiliar.Siguiente;
                    }

                    return true;
                }

                auxiliar = auxiliar.Siguiente;

            } while (auxiliar != primera);

            return false;
        }

        // Buscar una canción
        public void Buscar(string nombre)
        {
            if (primera == null)
            {
                Console.WriteLine("La playlist está vacía.");
                return;
            }

            Nodo auxiliar = primera;

            do
            {
                if (auxiliar.Datos.Nombre.Equals(nombre,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Canción encontrada:");
                    Console.WriteLine(auxiliar.Datos);
                    return;
                }

                auxiliar = auxiliar.Siguiente;

            } while (auxiliar != primera);

            Console.WriteLine("Canción no encontrada.");
        }

        // Reproducir la canción actual
        public void Reproducir()
        {
            if (actual == null)
            {
                Console.WriteLine("No hay canciones en la playlist.");
                return;
            }

            reproduciendo = true;
            Console.WriteLine("Reproduciendo: " + actual.Datos);
        }

        // Avanzar a la siguiente canción
        public void Siguiente()
        {
            if (actual == null)
            {
                Console.WriteLine("No hay canciones.");
                return;
            }

            if (!circular && actual.Siguiente == primera)
            {
                Console.WriteLine("Llegaste a la última canción.");
                return;
            }

            actual = actual.Siguiente;

            if (reproduciendo)
                Console.WriteLine("Reproduciendo: " + actual.Datos);
            else
                Console.WriteLine("Siguiente canción: " + actual.Datos);
        }

        // Regresar a la canción anterior
        public void Anterior()
        {
            if (actual == null)
            {
                Console.WriteLine("No hay canciones.");
                return;
            }

            if (!circular && actual == primera)
            {
                Console.WriteLine("Estás en la primera canción.");
                return;
            }

            actual = actual.Anterior;

            if (reproduciendo)
                Console.WriteLine("Reproduciendo: " + actual.Datos);
            else
                Console.WriteLine("Canción anterior: " + actual.Datos);
        }

        // Pausar la reproducción
        public void Pausar()
        {
            if (reproduciendo)
            {
                reproduciendo = false;
                Console.WriteLine("Reproducción pausada.");
            }
            else
            {
                Console.WriteLine("No hay ninguna reproducción activa.");
            }
        }

        // Mostrar todas las canciones
        public void Mostrar()
        {
            if (primera == null)
            {
                Console.WriteLine("La playlist está vacía.");
                return;
            }

            Console.WriteLine("===== " + nombrePlaylist + " =====");

            Nodo auxiliar = primera;

            do
            {
                if (auxiliar == actual)
                    Console.WriteLine(">> " + auxiliar.Datos);
                else
                    Console.WriteLine(auxiliar.Datos);

                auxiliar = auxiliar.Siguiente;

            } while (auxiliar != primera);
        }

        // Crear o cambiar el nombre de la playlist
        public void CrearPlaylist(string nombre)
        {
            nombrePlaylist = nombre;
            Console.WriteLine("Playlist creada correctamente.");
        }

        // Activar o desactivar la reproducción circular
        public void ReproduccionCircular()
        {
            circular = !circular;

            if (circular)
                Console.WriteLine("Reproducción circular activada.");
            else
                Console.WriteLine("Reproducción circular desactivada.");
        }
    }
}