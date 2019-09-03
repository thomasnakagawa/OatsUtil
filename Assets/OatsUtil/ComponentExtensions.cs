using UnityEngine;

namespace OatsUtil
{
    public static class ComponentExtensions
    {
        /// <summary>
        /// Checks for existance of attached component of specified type and returns it
        /// </summary>
        /// <typeparam name="T">The type of component required</typeparam>
        /// <param name="component">The component that reqires the other component</param>
        /// <returns>The attached component of type T or null if it doesn't exist</returns>
        public static T RequireComponent<T>(this Component component) where T: Component
        {
            T requiredComponent = component.GetComponent<T>();
            if (requiredComponent == null)
            {
                Debug.LogException(new MissingComponentException(component.name + " requires a " + typeof(T).ToString() + " component"), component);
            }
            return requiredComponent;
        }

        /// <summary>
        /// Checks for existance of a direct child transform with specified name and returns it
        /// </summary>
        /// <param name="component">The component that requires the child</param>
        /// <param name="childName">The name of the child to check for</param>
        /// <returns>The transform of the child or null if it doesn't exist</returns>
        public static Transform RequireChildGameObject(this Component component, string childName)
        {
            Transform childTransform = component.transform.Find(childName);
            if (childTransform == null)
            {
                Debug.LogException(new MissingGameObjectException(component.name + " requires a child GameObject called \"" + childName + "\""), component);
            }
            return childTransform;
        }
    }
}
