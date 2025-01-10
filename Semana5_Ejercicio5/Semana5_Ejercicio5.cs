using System;
using System.Collections.Generic;

//Escribir un programa que almacene el abecedario en una lista,
//elimine de la lista las letras que ocupen posiciones
//múltiplos de 3, y muestre por pantalla la lista resultante.

namespace Abecedario
{
    class Ejercicio5
    {
        static void Main(string[] args)
        {
            // Crear una lista con el abecedario
            List<char> abecedario = new List<char>();
            for (char letra = 'a'; letra <= 'z'; letra++)
            {
                abecedario.Add(letra);
            }

            // Crear una nueva lista excluyendo las posiciones múltiplos de 3
            List<char> resultado = new List<char>();
            for (int i = 0; i < abecedario.Count; i++)
            {
                // Las posiciones en la lista son 0-indexadas, por eso usamos (i + 1)
                if ((i + 1) % 3 != 0)
                {
                    resultado.Add(abecedario[i]);
                }
            }

            // Mostrar la lista resultante
            Console.WriteLine("Lista resultante:");
            Console.WriteLine(string.Join(", ", resultado));

            // Mantener la consola abierta
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}