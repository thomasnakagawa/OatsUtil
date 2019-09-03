using UnityEngine;

namespace OatsUtil
{
    /// <summary>
    /// Collection of methods for accessing GameObjects and Components in the current scene
    /// </summary>
    public static class SceneUtils
    {
        /// <summary>
        /// Finds an instance of a component in a scene
        /// </summary>
        /// <typeparam name="T">Type of component to find</typeparam>
        /// <returns>A component from the scene or null if none exists</returns>
        public static T FindComponentInScene<T>() where T : Component
        {
            T foundObject = Object.FindObjectOfType<T>();
            if (foundObject == null)
            {
                Debug.LogException(new MissingComponentException("No component of type " + typeof(T) + " was found in the scene"));
            }
            return foundObject;
        }

        /// <summary>
        /// Finds an instance of a component in a scene attached to a GameObject with a specified name
        /// </summary>
        /// <typeparam name="T">Type of component to find</typeparam>
        /// <param name="objectName">Name of the GameObject to find the component on</param>
        /// <returns>A component from the scene or null</returns>
        public static T FindComponentInScene<T>(string objectName) where T : Component
        {
            if (objectName == null)
            {
                throw new System.ArgumentNullException("objectName", "objectName cannot be null");
            }

            T[] foundObjects = Object.FindObjectsOfType<T>();
            if (foundObjects == null || foundObjects.Length < 1)
            {
                Debug.LogException(new MissingComponentException("No " + typeof(T) + " component was found in the scene"));
                return null;
            }
            foreach (T objectOfType in foundObjects)
            {
                if (objectOfType.name.Equals(objectName))
                {
                    return objectOfType;
                }
            }
            Debug.LogException(new MissingGameObjectException("No GameObject named " + objectName.Quote() + " with " + typeof(T) + " component was found in the scene, although " + typeof(T).ToString().Plural(foundObjects.Length) + " were found"));
            return null;
        }

        /// <summary>
        /// Finds a GameObject with the specified name or null if it doesn't exist in the scene
        /// </summary>
        /// <param name="objectName">Name of GameObject to find</param>
        /// <returns>GameObject with specified name or null</returns>
        public static GameObject FindObjectInScene(string objectName)
        {
            if (objectName == null)
            {
                throw new System.ArgumentNullException("objectName", "objectName cannot be null");
            }

            GameObject foundObject = GameObject.Find(objectName);
            if (foundObject == null)
            {
                Debug.LogException(new MissingGameObjectException("No Gameobject with name " + objectName.Quote() + " was found in the scene"));
                return null;
            }
            return foundObject;
        }
    }
}
