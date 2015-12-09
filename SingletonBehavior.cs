using UnityEngine;
using System.Collections;

namespace Kokychi
{

    public class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
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

        public bool IsKeepingAlive = true;

        private bool _isKeepingAlive = false;

        protected bool _IsKeepingAlive
        {
            get
            {
                return this._isKeepingAlive;
            }
        }

        protected void Awake()
        {

            this._isKeepingAlive = this.IsKeepingAlive;

            if (_instance == null)
            {
                Debug.Log("Firstly cast the _instance for " + this);

                _instance = this.GetComponent<T>();

                if (this._IsKeepingAlive)
                {
                    DontDestroyOnLoad(this.transform.gameObject);
                }
            }
            else
            {
                if (_instance != this)
                {
                    Destroy(this.transform.gameObject);

                    Debug.Log("This singleton has been already initialized!");
                }
            }
        }
        /*
       /// <summary>
       /// Call this function to keep the singleton alive
       /// on transition between level.
       /// <para>Pass parentBehavior as parameter to ensure persistent singleton.</para>
       /// </summary>
       protected void KeepAlive(MonoBehaviour parentBehavior)
       {
           // only keep the firstly initialized instance
           if (_instance == null)
           {
               Debug.Log("This singleton is freshly started " + this);

               // keep the instance alive
               // through map change
               DontDestroyOnLoad(Instance.transform.gameObject);
           }
           else 
           {
               // destroy the duplicate
               // gameObject.
               Debug.Log("Singleton " + this.ToString() + " is already existed. Removing duplicate.");

               Destroy(parentBehavior.transform.gameObject);
           }
       }
         * */
    }
}