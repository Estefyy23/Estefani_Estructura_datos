
 // Importar el espacio de nombres System para funcionalidades básicas

// Clase que representa un nodo del árbol binario
class Nodo
{
    public int Valor;       // Valor almacenado en el nodo (tipo primitivo entero)
    public Nodo Izquierdo;  // Referencia al hijo izquierdo
    public Nodo Derecho;    // Referencia al hijo derecho

    // Constructor del nodo
    public Nodo(int valor)
    {
        Valor = valor;      // Asigna el valor al nodo
        Izquierdo = null;   // Inicializa el hijo izquierdo como nulo
        Derecho = null;     // Inicializa el hijo derecho como nulo
    }
}

// Clase que implementa las operaciones de un árbol binario de búsqueda
class ArbolBinario
{
    private Nodo Raiz; // Nodo raíz del árbol

    // Constructor del árbol binario
    public ArbolBinario()
    {
        Raiz = null; // Inicializa el árbol vacío (raíz nula)
    }

    // Método público para insertar un valor en el árbol
    public void Insertar(int valor)
    {
        Raiz = InsertarRec(Raiz, valor); // Llama al método recursivo de inserción
    }

    // Método recursivo privado para insertar un valor
    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        // Si el nodo actual es nulo, hemos encontrado la posición de inserción
        if (nodo == null)
        {
            return new Nodo(valor); // Crea y devuelve un nuevo nodo
        }

        // Si el valor es menor que el valor del nodo actual, va al subárbol izquierdo
        if (valor < nodo.Valor)
        {
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor); // Llamada recursiva
        }
        // Si el valor es mayor que el valor del nodo actual, va al subárbol derecho
        else if (valor > nodo.Valor)
        {
            nodo.Derecho = InsertarRec(nodo.Derecho, valor); // Llamada recursiva
        }

        // Si el valor es igual, no se hace nada (no se permiten duplicados)
        return nodo; // Devuelve el nodo (modificado o no)
    }

    // Método público para buscar un valor en el árbol
    public bool Buscar(int valor)
    {
        return BuscarRec(Raiz, valor); // Llama al método recursivo de búsqueda
    }

    // Método recursivo privado para buscar un valor
    private bool BuscarRec(Nodo nodo, int valor)
    {
        // Si el nodo es nulo, el valor no existe en el árbol
        if (nodo == null)
        {
            return false;
        }

        // Si el valor coincide con el valor del nodo, lo hemos encontrado
        if (valor == nodo.Valor)
        {
            return true;
        }

        // Decide en qué subárbol continuar la búsqueda
        return valor < nodo.Valor 
            ? BuscarRec(nodo.Izquierdo, valor)  // Buscar en izquierdo si valor es menor
            : BuscarRec(nodo.Derecho, valor);  // Buscar en derecho si valor es mayor
    }

    // Método público para recorrido Inorden (izquierdo, raíz, derecho)
    public void Inorden()
    {
        InordenRec(Raiz); // Llama al método recursivo
        Console.WriteLine(); // Salto de línea al final
    }

    // Método recursivo privado para recorrido Inorden
    private void InordenRec(Nodo nodo)
    {
        if (nodo != null) // Si el nodo no es nulo
        {
            InordenRec(nodo.Izquierdo); // Recorre el subárbol izquierdo
            Console.Write(nodo.Valor + " "); // Imprime el valor del nodo
            InordenRec(nodo.Derecho); // Recorre el subárbol derecho
        }
    }

    // Método público para recorrido Preorden (raíz, izquierdo, derecho)
    public void Preorden()
    {
        PreordenRec(Raiz); // Llama al método recursivo
        Console.WriteLine(); // Salto de línea al final
    }

    // Método recursivo privado para recorrido Preorden
    private void PreordenRec(Nodo nodo)
    {
        if (nodo != null) // Si el nodo no es nulo
        {
            Console.Write(nodo.Valor + " "); // Imprime el valor del nodo primero
            PreordenRec(nodo.Izquierdo); // Luego recorre el subárbol izquierdo
            PreordenRec(nodo.Derecho); // Finalmente recorre el subárbol derecho
        }
    }

    // Método público para recorrido Postorden (izquierdo, derecho, raíz)
    public void Postorden()
    {
        PostordenRec(Raiz); // Llama al método recursivo
        Console.WriteLine(); // Salto de línea al final
    }

    // Método recursivo privado para recorrido Postorden
    private void PostordenRec(Nodo nodo)
    {
        if (nodo != null) // Si el nodo no es nulo
        {
            PostordenRec(nodo.Izquierdo); // Recorre primero el subárbol izquierdo
            PostordenRec(nodo.Derecho); // Luego el subárbol derecho
            Console.Write(nodo.Valor + " "); // Finalmente imprime el valor del nodo
        }
    }

    // Método público para eliminar un valor del árbol
    public void Eliminar(int valor)
    {
        Raiz = EliminarRec(Raiz, valor); // Llama al método recursivo de eliminación
    }

    // Método recursivo privado para eliminar un nodo
    private Nodo EliminarRec(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo; // Si el nodo es nulo, no hay nada que eliminar

        // Buscar el nodo a eliminar
        if (valor < nodo.Valor)
        {
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor); // Buscar en izquierdo
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecho = EliminarRec(nodo.Derecho, valor); // Buscar en derecho
        }
        else // Cuando encontramos el nodo a eliminar
        {
            // Caso 1: Nodo con un solo hijo o sin hijos
            if (nodo.Izquierdo == null)
                return nodo.Derecho; // Reemplaza con el hijo derecho
            else if (nodo.Derecho == null)
                return nodo.Izquierdo; // Reemplaza con el hijo izquierdo

            // Caso 2: Nodo con dos hijos
            // Obtener el sucesor inorden (mínimo en el subárbol derecho)
            nodo.Valor = MinValor(nodo.Derecho);

            // Eliminar el sucesor inorden
            nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Valor);
        }

        return nodo; // Devuelve el nodo (posiblemente modificado)
    }

    // Método privado para encontrar el valor mínimo en un subárbol
    private int MinValor(Nodo nodo)
    {
        int min = nodo.Valor; // Inicializa con el valor del nodo actual
        while (nodo.Izquierdo != null) // Mientras haya un hijo izquierdo
        {
            min = nodo.Izquierdo.Valor; // Actualiza el mínimo
            nodo = nodo.Izquierdo; // Avanza al siguiente nodo izquierdo
        }
        return min; // Devuelve el valor mínimo encontrado
    }

    // Método público para obtener la altura del árbol
    public int Altura()
    {
        return AlturaRec(Raiz); // Llama al método recursivo
    }

    // Método recursivo privado para calcular la altura
    private int AlturaRec(Nodo nodo)
    {
        if (nodo == null) // Si el nodo es nulo, altura 0
        {
            return 0;
        }

        // Calcula la altura de cada subárbol
        int alturaIzq = AlturaRec(nodo.Izquierdo);
        int alturaDer = AlturaRec(nodo.Derecho);

        // La altura del árbol es la máxima de las alturas + 1 (por el nodo actual)
        return Math.Max(alturaIzq, alturaDer) + 1;
    }

    // Método público para contar los nodos del árbol
    public int ContarNodos()
    {
        return ContarNodosRec(Raiz); // Llama al método recursivo
    }

    // Método recursivo privado para contar nodos
    private int ContarNodosRec(Nodo nodo)
    {
        if (nodo == null) // Si el nodo es nulo, no cuenta
        {
            return 0;
        }
        // Cuenta este nodo + los nodos de los subárboles izquierdo y derecho
        return 1 + ContarNodosRec(nodo.Izquierdo) + ContarNodosRec(nodo.Derecho);
    }

    // Método público para verificar si el árbol está vacío
    public bool EstaVacio()
    {
        return Raiz == null; // True si la raíz es nula, False en caso contrario
    }
}

// Clase principal con el método Main y el menú interactivo
class Program
{
    // Método principal
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario(); // Crea una instancia del árbol
        bool salir = false; // Variable de control para el bucle del menú

        // Bucle principal del menú
        while (!salir)
        {
            // Mostrar opciones del menú
            Console.WriteLine("\n--- MENÚ ÁRBOL BINARIO ---");
            Console.WriteLine("1. Insertar un valor");
            Console.WriteLine("2. Buscar un valor");
            Console.WriteLine("3. Recorrido Inorden");
            Console.WriteLine("4. Recorrido Preorden");
            Console.WriteLine("5. Recorrido Postorden");
            Console.WriteLine("6. Eliminar un valor");
            Console.WriteLine("7. Mostrar altura del árbol");
            Console.WriteLine("8. Contar número de nodos");
            Console.WriteLine("9. Verificar si el árbol está vacío");
            Console.WriteLine("10. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine(); // Leer la opción del usuario

            // Estructura switch para manejar las opciones
            switch (opcion)
            {
                case "1": // Insertar un valor
                    Console.Write("Ingrese el valor a insertar: ");
                    if (int.TryParse(Console.ReadLine(), out int valorInsertar))
                    {
                        arbol.Insertar(valorInsertar);
                        Console.WriteLine("Valor insertado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Por favor ingrese un número entero.");
                    }
                    break;

                case "2": // Buscar un valor
                    Console.Write("Ingrese el valor a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out int valorBuscar))
                    {
                        bool encontrado = arbol.Buscar(valorBuscar);
                        Console.WriteLine(encontrado ? "El valor está en el árbol." : "El valor NO está en el árbol.");
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Por favor ingrese un número entero.");
                    }
                    break;

                case "3": // Recorrido Inorden
                    Console.Write("Recorrido Inorden: ");
                    arbol.Inorden();
                    break;

                case "4": // Recorrido Preorden
                    Console.Write("Recorrido Preorden: ");
                    arbol.Preorden();
                    break;

                case "5": // Recorrido Postorden
                    Console.Write("Recorrido Postorden: ");
                    arbol.Postorden();
                    break;

                case "6": // Eliminar un valor
                    Console.Write("Ingrese el valor a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int valorEliminar))
                    {
                        arbol.Eliminar(valorEliminar);
                        Console.WriteLine("Operación completada.");
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Por favor ingrese un número entero.");
                    }
                    break;

                case "7": // Mostrar altura
                    Console.WriteLine($"Altura del árbol: {arbol.Altura()}");
                    break;

                case "8": // Contar nodos
                    Console.WriteLine($"Número de nodos en el árbol: {arbol.ContarNodos()}");
                    break;

                case "9": // Verificar si está vacío
                    Console.WriteLine(arbol.EstaVacio() ? "El árbol está vacío." : "El árbol NO está vacío.");
                    break;

                case "10": // Salir
                    salir = true;
                    break;

                default: // Opción no válida
                    Console.WriteLine("Opción no válida. Por favor seleccione una opción del 1 al 10.");
                    break;
            }

            // Pausa antes de limpiar la pantalla (excepto cuando se sale)
            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); // Limpiar la pantalla para la siguiente operación
            }
        }

        // Mensaje de despedida
        Console.WriteLine("Programa terminado. ¡Hasta luego!");
    }
}