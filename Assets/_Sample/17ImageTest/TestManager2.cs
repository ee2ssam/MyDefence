using UnityEngine;
using MyDefence;

namespace MySample
{
    /// <summary>
    /// 싱글톤 패턴을 적용한 테스트 매니저 클래스
    /// </summary>
    public class TestManager2 : PersistanctSingleton<TestManager2>
    {
        public string name = "홍길동";
    }
}
