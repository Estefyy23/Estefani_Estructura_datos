using System;
using System.Collections.Generic;

//Escribir un programa que pregunte al usuario los números ganadores
//de la lotería primitiva,los almacene en una lista y los muestre
//por pantalla ordenados de menor a mayor.

namespace LoteriaPrimitiva
{
    class Ejercicio3
    {
        static void Main(string[] args)
        {
            // Lista para almacenar los números ganadores
            List<int> numerosGanadores = new List<int>();

            Console.WriteLine("Introduce los 6 números ganadores de la lotería primitiva (entre 1 y 49):");

            while (numerosGanadores.Count < 6)
            {
                Console.Write($" \n Número {numerosGanadores.Count + 1}: ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int numero))
                {
                    if (numero >= 1 && numero <= 49 && !numerosGanadores.Contains(numero))
                    {
                        numerosGanadores.Add(numero);
                    }
                    else if (numerosGanadores.Contains(numero))
                    {
                        Console.WriteLine("El número ya ha sido introducido. Intenta con otro. \n");
                    }
                    else
                    {
                        Console.WriteLine("El número debe estar entre 1 y 49. Intenta nuevamente. \n");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, introduce un número. \n");
                }
            }

            // Ordenar los números ganadores de menor a mayor
            numerosGanadores.Sort();

            // Mostrar los números ganadores ordenados
            Console.WriteLine("\nLos números ganadores ordenados de menor a mayor son: \n");
            foreach (var numero in numerosGanadores)
            {
                Console.WriteLine(numero);
            }

            // Mantener la consola abierta
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}