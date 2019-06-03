using System;
using System.Collections.Generic;

/// <summary>
/// Created by Résmony S. Muniz
/// </summary>

namespace Recursions {
    class Program {
        /// <summary>
        ///  2) Escreva um app console em C# com os seguintes métodos:
        ///     1. Recursivo que imprima a média dos elementos de uma lista de inteiros e o número de elementos maiores do que a média.
        ///     2. Recursivo que retorne uma lista de forma invertida.
        /// Obs: Considere a lista previamente definida no próprio código.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            var list = GetRandomList(50);// new List<int> { 9, 5, 7, 2, 13, 5, 26, 3, 1, 6, 8, 4, 11 };
            var size = list.Count;

            var avg = (float)Sum(list, 0, size) / size;

            Console.WriteLine($"Lista: {string.Join(" ", list)}");
            Console.WriteLine($"\nMédia: {avg}");
            Console.WriteLine("\n{0} valores acima da média", AboveAverage(list, 0, size, avg, 0));

            ReverseArray(list, size, 0);

            Console.WriteLine("\n\nLista invertida: {0}", string.Join(" ", list));
            Console.ReadLine();
        }

        private static List<int> GetRandomList(int nums) {
            var rand = new Random();
            var list = new List<int>();
            for (var i = 0; i < nums; i++) {
                list.Add(rand.Next(0, 1000));
            }
            return list;
        }

        /// <summary>
        ///     Soma recursiva de uma lista de inteiros.
        /// </summary>
        /// <param name="list"> lista da de inteiros</param>
        /// <param name="i"> índice auxiliar para percorrer a lista</param>
        /// <param name="size"> tamanho da lista</param>
        /// <returns> A cada iteração acumula os valores de lista[i] + lista[i + 1] </returns>
        private static int Sum(IReadOnlyList<int> list, int i, int size) {
            if (i == size - 1) // caso base
                return list[i];

            return list[i] + Sum(list, i + 1, size);
        }

        /// <summary>
        ///     Calcula quantos elementos estão acima da média dada por Sum/Vector.Size
        /// </summary>
        /// <param name="list"> lista de inteiros</param>
        /// <param name="i"> índice auxiliar para percorrer a lista</param>
        /// <param name="size"> tamanho da lista</param>
        /// <param name="avg"> média calculada</param>
        /// <param name="above"> quantidade de valores acima da média</param>
        /// <returns> Retorna a quantidade de elementos que estão acima da média.</returns>
        private static int AboveAverage(IReadOnlyList<int> list, int i, int size, float avg, int above) {
            if (list[i] > avg) // caso base
                above++;

            return i == size - 1 ? above : AboveAverage(list, i + 1, size, avg, above);
        }

        /// <summary>
        ///    Método de inversão de conteúdo.
        /// </summary>
        /// <param name="list"> lista de inteiros</param>
        /// <param name="len"> tamanho da lista</param>
        /// <param name="start"> índice da lista para começar a reversão (start = 0)</param>
        private static void ReverseArray(List<int> list, int len, int start) {
            var low = start;
            var high = len - 1 - start;

            if (low >= high) // caso base 
                return;

            ArraySwap(list, low, high); // troca de posições
            ReverseArray(list, len, low + 1);

        }

        /// <summary>
        ///     Método auxiliar de ReverseArray para troca de posição do conteúdo da lista.
        /// </summary>
        /// <param name="list"> lista de inteiros</param>
        /// <param name="low"> índice na parte mais 'baixa' da lista</param>
        /// <param name="high"> índice na parte mais 'alta' da lista</param>
        private static void ArraySwap(List<int> list, int low, int high) {
            var temp = list[low];
            list[low] = list[high];
            list[high] = temp;
        }
    }
}
