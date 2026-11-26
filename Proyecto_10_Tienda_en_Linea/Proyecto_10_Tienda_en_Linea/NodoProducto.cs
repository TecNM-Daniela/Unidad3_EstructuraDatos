
using System;
using System.Collections.Generic;
namespace Proyecto_10_Tienda_en_Linea;


public class NodoProducto

{
    public Producto Producto;
    public NodoProducto Siguiente;


    public NodoProducto(Producto producto)

    {
        Producto = producto;
        Siguiente = null;
    }
}