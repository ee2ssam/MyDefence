using UnityEngine;

namespace Sample.Generic
{
    //SingletonManager 싱글톤 클래스
    public class SingletonManager : Singleton<SingletonManager>
    {
        //변수
        public int number = 1234;
    }
}
