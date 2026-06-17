using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Singleton<T> 상속받는 싱글톤 클래스
    /// MonoBehaviour 상속받는 싱글톤 클래스의 부모 클래스로 설계
    /// 씬 전환시 사라지지 않고 유지되어야 하는 싱글톤 클래스의 부모 클래스로 설계
    /// </summary>
    public class PersistanctSingleton<T> : Singleton<T> where T : Singleton<T>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
        }
}
}
