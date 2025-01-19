using System;

//Implementar un método dentro de la Implementar un método dentro 
//de la lista enlazada q lista enlazada que permita invertir los 
//datos ue permita invertir los datos
//almacenados en una lista enlazada, es decir que almacenados en 
//una lista enlazada, es decir que el primer elemento pase a ser 
//el último y el primer elemento pase a ser el último y el
//último pase a ser el primero, que el segundo sea el penúltimo y el penúltimo pase a ser el
//segundo y así segundo y así sucesivamente

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

    // Método para invertir la lista enlazada
    public void Invertir()
    {
        Nodo previo = null;    // Nodo anterior al actual
        Nodo actual = Cabeza;  // Nodo actual
        Nodo siguiente = null; // Nodo siguiente al actual

        while (actual != null)
        {
            siguiente = actual.Siguiente; // Guardar el nodo siguiente
            actual.Siguiente = previo;   // Invertir el enlace
            previo = actual;             // Mover el puntero previo al actual
            actual = siguiente;          // Avanzar al siguiente nodo
        }

        Cabeza = previo; // Actualizar la cabeza al último nodo procesado
    }

    // Método para mostrar los elementos de la lista
    public void Mostrar()
    {
        Nodo actual = Cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
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
        lista.Agregar(40);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        // Invirtiendo la lista
        lista.Invertir();

        Console.WriteLine("Lista invertida:");
        lista.Mostrar();
    }
}