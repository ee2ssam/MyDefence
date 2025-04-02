using UnityEngine;

namespace Sample
{
    public class PlayerTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //static 멤버 변수 사용하기
            StaticTest.number = 10;
            Debug.Log($"StaticTest.number: {StaticTest.number}");

            //싱글톤 패턴 클래스 인스턴스 생성(호출, 접근)
            //Singleton singleton = new Singleton(); // x
            //Debug.Log(singleton.ToString());

            /*var singletonA = Singleton.Instance;
            var singletonB = Singleton.Instance;
            if(singletonA == singletonB)
            {
                Debug.Log(singletonA.ToString());
            }*/

            //SingletonTest 클래스 사용하기
            SingletonTest.Instance.number = 99;
            Debug.Log($"SingletonTest.Instance.number: {SingletonTest.Instance.number}");

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}