using System;

namespace Proyecto7_Musica
{
    internal class Program
    {
        static ListaCircular playlist = new ListaCircular();

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== REPRODUCTOR DE MUSICA =====");
                Console.WriteLine("1. Agregar canción.");
                Console.WriteLine("2. Eliminar canción.");
                Console.WriteLine("3. Buscar canción.");
                Console.WriteLine("4. Reproducir.");
                Console.WriteLine("5. Siguiente.");
                Console.WriteLine("6. Anterior.");
                Console.WriteLine("7. Pausar.");
                Console.WriteLine("8. Mostrar playlist.");
                Console.WriteLine("9. Crear playlist.");
                Console.WriteLine("10. Reproducción circular.");
                Console.WriteLine("0. Salir.");
                Console.Write("Selecciona una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Canción: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Artista: ");
                        string artista = Console.ReadLine();

                        playlist.Agregar(new Cancion(nombre, artista));
                        break;

                    case 2:
                        Console.Write("Nombre de la canción a eliminar: ");
                        nombre = Console.ReadLine();

                        if (playlist.Eliminar(nombre))
                            Console.WriteLine("Canción eliminada.");
                        else
                            Console.WriteLine("Canción no encontrada.");
                        break;

                    case 3:
                        Console.Write("Nombre de la canción a buscar: ");
                        nombre = Console.ReadLine();

                        playlist.Buscar(nombre);
                        break;

                    case 4:
                        playlist.Reproducir();
                        break;

                    case 5:
                        playlist.Siguiente();
                        break;

                    case 6:
                        playlist.Anterior();
                        break;

                    case 7:
                        playlist.Pausar();
                        break;

                    case 8:
                        playlist.Mostrar();
                        break;

                    case 9:
                        Console.Write("Nombre de la playlist: ");
                        nombre = Console.ReadLine();

                        playlist.CrearPlaylist(nombre);
                        break;

                    case 10:
                        playlist.ReproduccionCircular();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del reproductor...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}