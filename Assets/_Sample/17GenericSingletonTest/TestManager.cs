using UnityEngine;

namespace Sample
{
    /// <summary>
    /// Singleton<T>을 상속받는 테스트 클래스
    /// </summary>
    public class TestManager : Singleton<TestManager>
    {
        public int number = 1234;
    }
}