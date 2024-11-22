using UnityEngine;

namespace Sample
{
    public class GenericNote : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            //Cup클래스의 인스턴스 선언하고 생성
            //Cup c = new Cup();  //사용불가

            //T: string 전용 - 문자열 컨텐츠를 저장하는 속성 생성
            Cup<string> text = new Cup<string>();
            text.Content = "문자열";

            //T: int 전용 - 정수형 컨텐츠를 저장하는 속성 생성
            Cup<int> number = new Cup<int>();
            number.Content = 1234;

            Debug.Log($"text.Content: {text.Content}, number.Content: {number.Content}");

            //T: 물컵 Water 전용 - Water 클래스의 객체를 저장하는 속성 생성
            Cup<Water> water = new Cup<Water>();
            //water.Content 는 Water의 인스턴스
            water.Content = new Water(); //Water의 인스턴스 생성
            water.Content.name = "홍길동";
            Debug.Log($"{water.Content.name}의 물컵");

            //T: 커피컵 Coffee 전용 - Coffee 클래스의 객체를 저장하는 속성 생성
            Cup<Coffee> coffee = new Cup<Coffee>();
            coffee.Content = new Coffee();
            Debug.Log(coffee.Content.ToString());

            //Singleton<T> 테스트
            SingletonTest2.Instance.number = 5678;
            Debug.Log($"SingletonTest2.Instance.number: {SingletonTest2.Instance.number}");
        }
    }
}