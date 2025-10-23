using UnityEngine;

namespace Sample
{
    /// <summary>
    /// PersistantSingleton<T>를 상속받는 테스트 클래스
    /// </summary>
    public class TestManager2 : PersistantSingleton<TestManager2>
    {
        public string name = "홍길동";
    }
}