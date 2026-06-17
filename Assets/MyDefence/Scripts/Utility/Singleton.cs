using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 제레릭 싱글톤 클래스
    /// MonoBehaviour 상속받는 싱글톤 클래스의 부모 클래스로 설계
    /// MonoBehaviour 상속받는 클래스에서 싱글톤 패턴을 쉽게 구현할 수 있도록 도와주는 클래스
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = (T)this;
        }
    }
}

