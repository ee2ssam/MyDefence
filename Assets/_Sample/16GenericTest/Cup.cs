using UnityEngine;

//제네릭 클래스: 형식 매개변수 T에 지정한 형식으로 클래스와 멤버의 성질을 결정되는 클래스
namespace Sample
{
    public class Water
    {
        public string name;
    }

    public class Coffee { }


    //클래스 이름<T> 형태로 제네릭 클래스 선언
    public class Cup<T>
    {
        public T Content { get; set; }

        public void PrintData(T data)
        {
            Debug.Log(data);
        }
    }
}