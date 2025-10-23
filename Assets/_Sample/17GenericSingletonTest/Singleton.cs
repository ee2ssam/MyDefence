using UnityEngine;

namespace Sample
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get { return instance; }
        }

        public static bool InstanceExist
        {
            get { return instance != null; }
        }

        protected virtual void Awake()
        {
            if(InstanceExist)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = (T)this;

        }
    }
}