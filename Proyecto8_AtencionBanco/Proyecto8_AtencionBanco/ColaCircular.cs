using System;

namespace Proyecto8_AtencionBanco
{
    public class ColaCircular
    {
        private Cliente?[] elementos;
        private int frente;
        private int cantidad;

        public ColaCircular(int capacidad)
        {
            elementos = new Cliente[capacidad];
            frente = 0;
            cantidad = 0;
        }

        public void Insertar(Cliente cliente)
        {
            if (cantidad < elementos.Length)
            {
                int posicion = (frente + cantidad) % elementos.Length;
                elementos[posicion] = cliente;
                cantidad++;
            }
            else
            {
                elementos[frente] = cliente;
                frente = (frente + 1) % elementos.Length;
            }
        }

        public void Mostrar()
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No hay clientes atendidos.");
                return;
            }

            for (int i = 0; i < cantidad; i++)
            {
                int posicion = (frente + i) % elementos.Length;
                Console.WriteLine(elementos[posicion]);
            }
        }
    }
}