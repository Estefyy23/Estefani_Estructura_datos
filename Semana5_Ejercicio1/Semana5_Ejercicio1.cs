using System;
using System.Collections.Generic;

//Escribir un programa que almacene las asignaturas de un curso
//(por ejemplo Matemáticas, Física,Química, Historia y Lengua)
//en una lista y la muestre por pantalla.

namespace AsignaturasCurso
{
    // Clase que representa un curso
    public class Curso
    {
        // Propiedad para almacenar la lista de asignaturas
        public List<string> Asignaturas { get; private set; }

        // Constructor que inicializa la lista de asignaturas
        public Curso()
        {
            Asignaturas = new List<string>();
        }

        // Método para agregar una asignatura al curso
        public void AgregarAsignatura(string asignatura)
        {
            if (!string.IsNullOrWhiteSpace(asignatura))
            {
                Asignaturas.Add(asignatura);
            }
            else
            {
                Console.WriteLine("La asignatura no puede estar vacía.");
            }
        }

        // Método para mostrar las asignaturas por pantalla
        public void MostrarAsignaturas()
        {
            Console.WriteLine("Asignaturas del curso: \n");
            foreach (var asignatura in Asignaturas)
            {
                Console.WriteLine($"- {asignatura}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase Curso
            Curso curso = new Curso();

            // Agregar asignaturas al curso
            curso.AgregarAsignatura("Matemáticas \n");
            curso.AgregarAsignatura("Física \n");
            curso.AgregarAsignatura("Química \n");
            curso.AgregarAsignatura("Historia \n");
            curso.AgregarAsignatura("Lengua \n");

            // Mostrar las asignaturas por pantalla
            curso.MostrarAsignaturas();

            // Mantener la consola abierta
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}