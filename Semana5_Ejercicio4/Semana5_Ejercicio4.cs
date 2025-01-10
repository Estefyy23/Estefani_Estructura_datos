using System;
using System.Collections.Generic;

//Escribir un programa que almacene en una lista los números del 1 al 10 y
//los muestre por pantalla en orden inverso separados por comas.
namespace NumerosInvertidos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista con los números del 1 al 10
            List<int> numeros = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }

            // Invertir la lista
            numeros.Reverse();

            // Mostrar los números en orden inverso separados por comas
            Console.WriteLine("Números en orden inverso:");
            Console.WriteLine(string.Join(", ", numeros));

            // Mantener la consola abierta
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
