using System;
using System.Collections.Generic;

namespace TummyTime.Extensions {
    static class ListExtensions {

        /// <summary>
        /// Fisher-Yates shuffle
        /// </summary>
        /// <param name="list">List.</param>
        /// <param name="rng">Rng.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Shuffle<T>(this IList<T> list, Random rng) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


    }
}
