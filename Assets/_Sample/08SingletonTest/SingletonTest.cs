using UnityEngine;

namespace MySample
{
    public class SingletonTest : MonoBehaviour
    {
        #region Unity Event Method
        private void Start()
        {
            SingletonClass.Instance.number = 10;
            Debug.Log(SingletonClass.Instance.number.ToString());
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