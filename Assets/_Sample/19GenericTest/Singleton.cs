using UnityEngine;

namespace Sample.Generic
{
    //제네릭 싱글톤 클래스
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        //클래스의 인스턴스 변수를 정적(static)변수로 선언
        private static T instance;

        //public한 속성로 instance를 전역적으로 접근하기
        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        //싱글톤 객체 존재여부 체크
        public static bool InstanceExist
        {
            get
            {
                return instance != null;
            }
        }

        protected virtual void Awake()
        {
            //싱글톤을 가진 오브젝트가 이미 존재하면
            if (instance != null)
            {
                //this 오브젝트를 킬
                Destroy(gameObject);
                return;
            }
            instance = (T)this;
        }

        //오브젝트 킬할때 instance 초기화
        protected virtual void OnDestroy()
        {
            if(instance == this)
            {
                instance = null;
            }
        }
    }
}
