using System;

namespace Proyecto_10_Tienda_en_Linea
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaProductos lista = new ListaProductos();
            ColaPrioridadPedidos pedidos = new ColaPrioridadPedidos();
            HistorialOperaciones historial = new HistorialOperaciones();

            int opcion;

            do
            {
                Console.WriteLine("\n===== SISTEMA DE GESTIÓN DE PEDIDOS =====");
                Console.WriteLine("1. Registrar Producto");
                Console.WriteLine("2. Buscar Producto");
                Console.WriteLine("3. Eliminar Producto");
                Console.WriteLine("4. Registrar Pedido");
                Console.WriteLine("5. Cancelar Pedido");
                Console.WriteLine("6. Procesar Pedido");
                Console.WriteLine("7. Mostrar Productos");
                Console.WriteLine("8. Historial");
                Console.WriteLine("0. Salir");

                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Precio: ");
                        double precio = double.Parse(Console.ReadLine());

                        Console.Write("Existencias: ");
                        int stock = int.Parse(Console.ReadLine());

                        Console.Write("Categoría: ");
                        string categoria = Console.ReadLine();

                        lista.Agregar(new Producto(id, nombre, precio, stock, categoria));

                        historial.Agregar("Producto registrado: " + nombre);

                        Console.WriteLine("Producto agregado.");
                        break;

                    case 2:
                        Console.Write("ID del producto: ");
                        int buscar = int.Parse(Console.ReadLine());

                        Producto p = lista.Buscar(buscar);

                        if (p != null)
                            Console.WriteLine(p);
                        else
                            Console.WriteLine("Producto no encontrado.");

                        break;

                    case 3:
                        Console.Write("ID a eliminar: ");
                        int eliminar = int.Parse(Console.ReadLine());

                        if (lista.Eliminar(eliminar))
                        {
                            historial.Agregar("Producto eliminado ID: " + eliminar);
                            Console.WriteLine("Producto eliminado.");
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                        break;

                    case 4:
                        Console.Write("Número Pedido: ");
                        int num = int.Parse(Console.ReadLine());

                        Console.Write("Cliente: ");
                        string cliente = Console.ReadLine();

                        Console.Write("Productos: ");
                        string productos = Console.ReadLine();

                        Console.Write("Total: ");
                        double total = double.Parse(Console.ReadLine());

                        Console.Write("Prioridad (URGENTE/NORMAL): ");
                        string prioridad = Console.ReadLine();

                        Pedido pedido = new Pedido(
                            num,
                            cliente,
                            productos,
                            total,
                            prioridad);

                        pedidos.Encolar(pedido);

                        historial.Agregar("Pedido registrado: #" + num);

                        Console.WriteLine("Pedido registrado.");
                        break;

                    case 5:
                        Console.WriteLine("Pedido cancelado.");
                        historial.Agregar("Pedido cancelado");
                        break;

                    case 6:
                        Pedido procesado = pedidos.Procesar();

                        if (procesado != null)
                        {
                            procesado.Estado = "Procesado";

                            Console.WriteLine("Procesando:");
                            Console.WriteLine(procesado);

                            historial.Agregar("Pedido procesado: #" + procesado.Numero);
                        }
                        else
                        {
                            Console.WriteLine("No hay pedidos pendientes.");
                        }
                        break;

                    case 7:
                        lista.Mostrar();
                        break;

                    case 8:
                        historial.Mostrar();
                        break;
                }

            } while (opcion != 0);
        }
    }
}