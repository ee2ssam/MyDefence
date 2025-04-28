using UnityEngine;

namespace Sample.Generic
{
    //제네릭 싱글톤 클래스 : 씬 전환시 파괴되지 않는다
    public class PersistanceSingleton<T> : Singleton<T> where T : Singleton<T>
    {
        protected override void Awake()
        {
            base.Awake();

            //씬 전환시 파괴되지 않는다
            DontDestroyOnLoad(gameObject);
        }
    }
}