using System;
using System.Collections.Generic;
using System;

namespace Proyecto_10_Tienda_en_Linea;

public class Pedido
{
    public int Numero { get; set; }
    public string Cliente { get; set; }
    public DateTime Fecha { get; set; }
    public string Productos { get; set; }
    public double Total { get; set; }
    public string Prioridad { get; set; }
    public string Estado { get; set; }

    public Pedido(int numero, string cliente, string productos,
                 double total, string prioridad)
    {
        Numero = numero;
        Cliente = cliente;
        Productos = productos;
        Total = total;
        Prioridad = prioridad;
        Fecha = DateTime.Now;
        Estado = "Pendiente";
    }

    public override string ToString()
    {
        return $"Pedido #{Numero} | Cliente: {Cliente} | Total: ${Total} | Prioridad: {Prioridad} | Estado: {Estado}";
    }
}