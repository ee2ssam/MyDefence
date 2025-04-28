using UnityEngine;

namespace Sample.Generic
{
    public class GenericDemo : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //Cup(제네릭) 클래스의 객체 생성
            //Cup cup = new Cup();  // x
            //int형 데이터를 저장하는 속성을 가진 객체 생성
            Cup<int> number = new Cup<int>();
            number.Contents = 1234;

            //stirng형 데이터를 저장하는 속성을 가진 객체 생성
            Cup<string> text = new Cup<string>();
            text.Contents = "문자열 전용컵";
            Debug.Log($"{number.Contents} - {text.Contents}");

            //물컵 전용
            Cup<Water> waterCup = new Cup<Water>();
            Water water = new Water();
            waterCup.Contents = water;
            Debug.Log(waterCup.Contents.ToString());
        }
    }
}