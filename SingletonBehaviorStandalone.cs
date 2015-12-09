using UnityEngine;
using System.Collections;

namespace Kokychi
{

    public class SingletonBehaviorStandalone<T> where T : MonoBehaviour
    {

        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    // find the instance in
                    // the inspector
                    _instance = GameObject.FindObjectOfType<T>();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Call this function to keep the singleton alive
        /// on transition between level.
        /// <para>Pass parentBehavior as parameter to ensure persistent singleton.</para>
        /// </summary>
        internal void DontDestroyOnLoad(MonoBehaviour parentBehavior)
        {
            if (_instance != null && _instance == parentBehavior)
            {
                // keep the instance alive
                // through map change
                MonoBehaviour.DontDestroyOnLoad(_instance.gameObject);
            }
            else if (_instance != null)
            {
                // destroy the duplicate
                // gameObject.
                Debug.Log("Singleton " + this.ToString() + " is already existed. Removing duplicate.");

                MonoBehaviour.Destroy(parentBehavior);
            }
        }
    }
}