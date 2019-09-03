using System.Collections.Generic;

namespace OatsUtil
{
    public static class CollectionExtensions
    {
        private static readonly System.Random defaultRandom = new System.Random();

        /// <summary>
        /// Returns a random element from a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list to choose a random element from</param>
        /// <param name="random">Random object to use to generate randomness</param>
        /// <returns></returns>
        public static T Random<T>(this IList<T> list, System.Random random)
        {
            return list[random.Next(0, list.Count)];
        }

        /// <summary>
        /// Returns a random element from a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list to choose a random element from</param>
        /// <returns></returns>
        public static T Random<T>(this IList<T> list)
        {
            return list.Random(defaultRandom);
        }

        /// <summary>
        /// Returns a random element from an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array to choose a random element from</param>
        /// <param name="random">Random object to use to generate randomness</param>
        /// <returns></returns>
        public static T Random<T>(this T[] array, System.Random random)
        {
            return array[random.Next(0, array.Length)];
        }

        /// <summary>
        /// Returns a random element from an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array to choose a random element from</param>
        /// <returns></returns>
        public static T Random<T>(this T[] array)
        {
            return array.Random(defaultRandom);
        }

        /// <summary>
        /// Randomizes the order of elements in a list in place
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">List to shuffle</param>
        /// <param name="random">The Random object to use to generate randomness</param>
        public static void Shuffle<T>(this IList<T> list, System.Random random)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Randomizes the order of elements in a list in place, using a default seeded Random object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">List to shuffle</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            list.Shuffle(defaultRandom);
        }
    }
}
