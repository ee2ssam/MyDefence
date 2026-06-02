using UnityEngine;

namespace MySample
{
    public class SingletonTest : MonoBehaviour
    {
        #region Unity Event Method
        private void Start()
        {
            //정적 멤버 변수 사용하기(전역적 접근) : 클래스이름.멤버변수이름
            StaticTest.number = 20;
            Debug.Log(StaticTest.number.ToString());

            //싱글톤 패턴 클래스 인스턴스를 이용하여 멤버변수 사용하기 : 클래스이름.인스턴스이름.멤버변수이름
            //싱글톤 패턴 클래스 new를 사용하지 않는다, 클래스 안에서 자동으로 생성 해주었다
            //SingletonClass singletonClass = new SingletonClass(); X
            var singletonClassA = SingletonClass.Instance;
            var singletonClassB = SingletonClass.Instance;
            if(singletonClassA == singletonClassB)
            {
                Debug.Log(singletonClassA.ToString());
            }

            SingletonClass.Instance.number = 10;
            Debug.Log(SingletonClass.Instance.number.ToString());

            //모노 싱글톤 패턴 클래스 인스턴스를 이용하여 멤버변수 사용하기 : 클래스이름.인스턴스이름.멤버변수이름
            SingletonMono.Instance.number = 30;
            Debug.Log(SingletonMono.Instance.number.ToString());

        }
        #endregion
    }
}

/*
디자인 패턴

싱글톤(Singleton) 패턴
: 프로젝트 내에서 하나의 인스턴스만 존재하게 한다, new를 한번만 한다
: 클래스의 인스턴스에게 전역적으로 접근이 가능하다, 인스턴스 변수를 static으로 선언

: 싱글톤 클래스의 인스턴스 변수는 자신 클래스의 코드블록 안에서 선언하고 객체를 가져온다
*/