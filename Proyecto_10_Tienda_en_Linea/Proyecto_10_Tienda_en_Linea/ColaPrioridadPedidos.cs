using System;
using System.Collections.Generic;

namespace Proyecto_10_Tienda_en_Linea
{
    public class ColaPrioridadPedidos
    {
        private Queue<Pedido> urgentes = new Queue<Pedido>();
        private Queue<Pedido> normales = new Queue<Pedido>();

        public void Encolar(Pedido pedido)
        {
            if (pedido.Prioridad.ToUpper() == "URGENTE")
            {
                urgentes.Enqueue(pedido);
            }
            else
            {
                normales.Enqueue(pedido);
            }
        }

        public Pedido Procesar()
        {
            if (urgentes.Count > 0)
                return urgentes.Dequeue();

            if (normales.Count > 0)
                return normales.Dequeue();

            return null;
        }

        public bool Cancelar(int numero)
        {
            Queue<Pedido> auxiliar = new Queue<Pedido>();
            bool encontrado = false;

            while (urgentes.Count > 0)
            {
                Pedido actual = urgentes.Dequeue();

                if (actual.Numero == numero && !encontrado)
                {
                    encontrado = true;
                }
                else
                {
                    auxiliar.Enqueue(actual);
                }
            }

            urgentes = auxiliar;

            auxiliar = new Queue<Pedido>();

            while (normales.Count > 0)
            {
                Pedido actual = normales.Dequeue();

                if (actual.Numero == numero && !encontrado)
                {
                    encontrado = true;
                }
                else
                {
                    auxiliar.Enqueue(actual);
                }
            }

            normales = auxiliar;

            return encontrado;
        }

        public void Mostrar()
        {
            if (Vacia())
            {
                Console.WriteLine("No hay pedidos pendientes.");
                return;
            }

            Console.WriteLine("\n--- PEDIDOS URGENTES ---");

            if (urgentes.Count == 0)
            {
                Console.WriteLine("No hay pedidos urgentes.");
            }
            else
            {
                foreach (Pedido pedido in urgentes)
                {
                    Console.WriteLine(pedido);
                }
            }

            Console.WriteLine("\n--- PEDIDOS NORMALES ---");

            if (normales.Count == 0)
            {
                Console.WriteLine("No hay pedidos normales.");
            }
            else
            {
                foreach (Pedido pedido in normales)
                {
                    Console.WriteLine(pedido);
                }
            }
        }

        public bool Vacia()
        {
            return urgentes.Count == 0 && normales.Count == 0;
        }
    }
}