using System;
using System.Collections.Generic;

//Tomando en cuenta la teoría de la clase sobre pilas, resuelva 
//el código en C# la verificación  de una operación matemática se encuentran balanceados
//: Ej: {7+(8*5)-[(9-7)+(4+1)]} resultado => formula balanceada.

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese la fórmula matemática:");
        string formula = Console.ReadLine();

        if (EsFormulaBalanceada(formula))
        {
            Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Fórmula no balanceada.");
        }
    }

    static bool EsFormulaBalanceada(string formula)
    {
        // Pila para almacenar los símbolos de apertura
        Stack<char> pila = new Stack<char>();

        // Recorrer la fórmula carácter por carácter
        foreach (char c in formula)
        {
            // Si es un símbolo de apertura, agregarlo a la pila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si es un símbolo de cierre, verificar correspondencia
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, no está balanceado
                if (pila.Count == 0)
                {
                    return false;
                }

                // Sacar el símbolo de apertura más reciente
                char apertura = pila.Pop();

                // Verificar si el símbolo coincide
                if (!SimbolosCoinciden(apertura, c))
                {
                    return false;
                }
            }
        }

        // Si la pila está vacía al final, está balanceado
        return pila.Count == 0;
    }

    static bool SimbolosCoinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }
}
