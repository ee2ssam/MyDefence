using UnityEngine;
using MyDefence;

namespace MySample
{
    /// <summary>
    /// 싱글톤 패턴을 적용한 테스트 매니저 클래스
    /// </summary>
    public class TestManager : Singleton<TestManager>
    {
        public int number = 1234;
    }
}
