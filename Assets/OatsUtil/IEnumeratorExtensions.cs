using System.Collections;

namespace OatsUtil
{
    public static class IEnumeratorExtensions
    {
        /// <summary>
        /// Runs an IEnumerator after another IEnumerator in a sequence when executed in a coroutine
        /// </summary>
        /// <param name="enumerator">The Enumerator to run first</param>
        /// <param name="next">The Enumerator to run next</param>
        /// <returns>Enumerator with the Enumerators concatenated</returns>
        public static IEnumerator Then(this IEnumerator enumerator, IEnumerator next)
        {
            yield return enumerator;
            yield return next;
        }

        /// <summary>
        /// Runs an Action after an IEnumerator in a sequence when executed in a coroutine
        /// </summary>
        /// <param name="enumerator">The Enumerator to run first</param>
        /// <param name="next">The action to run next</param>
        /// <returns>Enumerator with the action invoked after the enumerator</returns>
        public static IEnumerator Then(this IEnumerator enumerator, System.Action next)
        {
            yield return enumerator;
            next.Invoke();
        }
    }
}
