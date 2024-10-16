using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static HashSet<int> universo = new HashSet<int>();
    static List<HashSet<int>> conjuntos = new List<HashSet<int>>();

    static void Main()
    {

        // Julio César Carrillo García 1790-24-22116
        // María Reneé Velásquez Quevedo 1790-24-14352
        IngresarUniverso();
        IngresarConjuntos();
        Menu();
    }

    static void IngresarUniverso()
    {
        Console.WriteLine("Ingrese los elementos del universo (separados por espacios):");
        string[] elementos = Console.ReadLine().Split();
        foreach (var elemento in elementos)
        {
            if (int.TryParse(elemento, out int numero))
            {
                universo.Add(numero);
            }
        }
        Console.WriteLine("Universo ingresado.");
    }

    static void IngresarConjuntos()
    {
        Console.WriteLine("¿Cuántos conjuntos desea ingresar?");
        int cantidadConjuntos = int.Parse(Console.ReadLine());

        for (int i = 0; i < cantidadConjuntos; i++)
        {
            Console.WriteLine($"Ingrese los elementos del conjunto {i + 1} (máximo 10 elementos, separados por espacios):");
            string[] elementos = Console.ReadLine().Split();
            HashSet<int> conjunto = new HashSet<int>();

            foreach (var elemento in elementos)
            {
                if (int.TryParse(elemento, out int numero) && conjunto.Count < 10)
                {
                    conjunto.Add(numero);
                }
            }
            conjuntos.Add(conjunto);
        }
        Console.WriteLine("Conjuntos ingresados.");
    }

    static void Menu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- OPERACIONES CONJUNTOS ---");
            Console.WriteLine("1. Unión");
            Console.WriteLine("2. Intersección");
            Console.WriteLine("3. Diferencia");
            Console.WriteLine("4. Diferencia Simétrica");
            Console.WriteLine("5. Complemento");
            Console.WriteLine("6. Producto Cartesiano");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion >= 1 && opcion <= 6)
            {
                Console.WriteLine("Seleccione el primer conjunto (número):");
                MostrarConjuntos();
                int conjunto1Index = int.Parse(Console.ReadLine()) - 1;

                HashSet<int> conjunto1 = conjuntos[conjunto1Index];

                HashSet<int> conjunto2 = null;
                if (opcion != 5) // El complemento solo requiere un conjunto
                {
                    Console.WriteLine("Seleccione el segundo conjunto (número):");
                    MostrarConjuntos();
                    int conjunto2Index = int.Parse(Console.ReadLine()) - 1;
                    conjunto2 = conjuntos[conjunto2Index];
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Unión: " + string.Join(", ", Union(conjunto1, conjunto2)));
                        break;
                    case 2:
                        Console.WriteLine("Intersección: " + string.Join(", ", Interseccion(conjunto1, conjunto2)));
                        break;
                    case 3:
                        Console.WriteLine("Diferencia: " + string.Join(", ", Diferencia(conjunto1, conjunto2)));
                        break;
                    case 4:
                        Console.WriteLine("Diferencia Simétrica: " + string.Join(", ", DiferenciaSimetrica(conjunto1, conjunto2)));
                        break;
                    case 5:
                        Console.WriteLine("Complemento: " + string.Join(", ", Complemento(conjunto1)));
                        break;
                    case 6:
                        Console.WriteLine("Producto Cartesiano: ");
                        ProductoCartesiano(conjunto1, conjunto2);
                        break;
                }
            }
        } while (opcion != 7);
    }

    static void MostrarConjuntos()
    {
        for (int i = 0; i < conjuntos.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {{ {string.Join(", ", conjuntos[i])} }}");
        }
    }

    // Operaciones
    static HashSet<int> Union(HashSet<int> conjunto1, HashSet<int> conjunto2)
    {
        return new HashSet<int>(conjunto1.Union(conjunto2));
    }

    static HashSet<int> Interseccion(HashSet<int> conjunto1, HashSet<int> conjunto2)
    {
        return new HashSet<int>(conjunto1.Intersect(conjunto2));
    }

    static HashSet<int> Diferencia(HashSet<int> conjunto1, HashSet<int> conjunto2)
    {
        return new HashSet<int>(conjunto1.Except(conjunto2));
    }

    // Implementación manual de la diferencia simétrica
    static HashSet<int> DiferenciaSimetrica(HashSet<int> conjunto1, HashSet<int> conjunto2)
    {
        var union = conjunto1.Union(conjunto2); // Unión de los dos conjuntos
        var interseccion = conjunto1.Intersect(conjunto2); // Intersección de los dos conjuntos
        return new HashSet<int>(union.Except(interseccion)); // Diferencia simétrica: elementos en la unión que no están en la intersección
    }

    static HashSet<int> Complemento(HashSet<int> conjunto)
    {
        return new HashSet<int>(universo.Except(conjunto));
    }

    static void ProductoCartesiano(HashSet<int> conjunto1, HashSet<int> conjunto2)
    {
        foreach (var elemento1 in conjunto1)
        {
            foreach (var elemento2 in conjunto2)
            {
                Console.WriteLine($"({elemento1}, {elemento2})");
            }
        }
    }
}