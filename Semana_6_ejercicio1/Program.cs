using System;

//La idea de este algoritmo es bastante sencilla, 
//lo que tendremos q hacer para ver la longitud de
//una lista es simplemente recorrer la lista hasta el
// final e ir contando el número de saltos. El principal
// motivo por el que deberíamos implementar es que nos es
// que nos permite aprender y comprender permite aprender y comprender
//el manejo de los nodos.


class Nodo
{
    public int Valor;      // Valor del nodo
    public Nodo Siguiente; // Referencia al siguiente nodo

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    public Nodo Cabeza; // Primer nodo de la lista

    public ListaEnlazada()
    {
        Cabeza = null;
    }

    // Método para agregar un nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    // Función para calcular el número de elementos de la lista
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = Cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente; // Pasar al siguiente nodo
        }

        return contador;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregando elementos a la lista
        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);

        // Contando los elementos de la lista
        int cantidad = lista.ContarElementos();
        Console.WriteLine($"El número de elementos en la lista es: {cantidad}");
    }
}