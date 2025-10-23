using UnityEngine;

namespace Sample
{
    public class GenericDemo : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //Cup 클래스의 객체 생성
            //Cup c = new Cup();

            //[1] T에 string 형식으로 지정하여 Cup 클래스의 객체 생성
            Cup<string> text = new Cup<string>();
            text.Content = "문자열";

            //[2] T에 int 형식으로 지정하여 Cup 클래스의 객체 생성
            Cup<int> number = new Cup<int>();
            number.Content = 1234;

            Debug.Log($"{text.Content} + {number.Content}");

            //[3] T에 Water 형식으로 지정하여 Cup 클래스의 객체 생성
            Cup<Water> water = new Cup<Water>();
            water.Content = new Water();
            Debug.Log(water.Content.ToString());

            //[4]Singleton<T>을 상속받는 테스트 클래스 예제
            TestManager.Instance.number = 5678;
            Debug.Log(TestManager.Instance.number.ToString());

            //[5]PesistantSingleton<T>을 상속받는 테스트 클래스 예제
            TestManager2.Instance.name = "백두산";
            Debug.Log(TestManager2.Instance.name);

        }
    }
}