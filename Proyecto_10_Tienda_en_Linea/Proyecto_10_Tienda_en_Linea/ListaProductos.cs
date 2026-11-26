
using System;
using System.Collections.Generic;


namespace Proyecto_10_Tienda_en_Linea;

public class ListaProductos
{
    private NodoProducto cabeza;

    public void Agregar(Producto producto)
    {
        NodoProducto nuevo = new NodoProducto(producto);

        if (cabeza == null)
        {
            cabeza = nuevo;
            return;
        }

        NodoProducto aux = cabeza;

        while (aux.Siguiente != null)
        {
            aux = aux.Siguiente;
        }

        aux.Siguiente = nuevo;
    }

    public Producto Buscar(int id)
    {
        NodoProducto aux = cabeza;

        while (aux != null)
        {
            if (aux.Producto.ID == id)
                return aux.Producto;

            aux = aux.Siguiente;
        }

        return null;
    }

    public bool Eliminar(int id)
    {
        if (cabeza == null)
            return false;

        if (cabeza.Producto.ID == id)
        {
            cabeza = cabeza.Siguiente;
            return true;
        }

        NodoProducto actual = cabeza;

        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Producto.ID == id)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return true;
            }
            actual = actual.Siguiente;
        }

        return false;
    }

    public void Mostrar()
    {
        NodoProducto aux = cabeza;

        while (aux != null)
        {
            Console.WriteLine(aux.Producto);
            aux = aux.Siguiente;
        }
    }
}