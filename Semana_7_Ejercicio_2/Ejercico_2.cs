using System;
using System.Collections.Generic;

//Realice un algoritmo en C# y el uso de pilas 
//para resolver el problema de las torres de Hanoi.

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese el número de discos:");
        int n = int.Parse(Console.ReadLine());

        // Crear las tres torres (pilas)
        Stack<int> torreOrigen = new Stack<int>();
        Stack<int> torreAuxiliar = new Stack<int>();
        Stack<int> torreDestino = new Stack<int>();

        // Inicializar la torre origen con los discos
        for (int i = n; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Mostrar estado inicial
        Console.WriteLine("Estado inicial:");
        MostrarTorres(torreOrigen, torreAuxiliar, torreDestino);

        // Resolver el problema
        ResolverHanoi(n, torreOrigen, torreDestino, torreAuxiliar, "Origen", "Destino", "Auxiliar");

        // Mostrar estado final
        Console.WriteLine("Estado final:");
        MostrarTorres(torreOrigen, torreAuxiliar, torreDestino);
    }

    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (n == 1)
        {
            // Mover el disco de la torre origen a la torre destino
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco 1 de {nombreOrigen} a {nombreDestino}");
        }
        else
        {
            // Mover n-1 discos de la torre origen a la torre auxiliar
            ResolverHanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

            // Mover el disco n de la torre origen a la torre destino
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco {n} de {nombreOrigen} a {nombreDestino}");

            // Mover los n-1 discos de la torre auxiliar a la torre destino
            ResolverHanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }

    static void MostrarTorres(Stack<int> torreOrigen, Stack<int> torreAuxiliar, Stack<int> torreDestino)
    {
        Console.WriteLine("Origen: " + string.Join(", ", torreOrigen));
        Console.WriteLine("Auxiliar: " + string.Join(", ", torreAuxiliar));
        Console.WriteLine("Destino: " + string.Join(", ", torreDestino));
        Console.WriteLine();
    }
}
