using UnityEngine;

namespace Sample
{
    public class Water { }
    public class Coffee { }

    //제네릭 클래스 만들기, 클래스 이름<T>
    public class Cup<T>
    {
        public T Content { get; set; }

        public void PrintData(T data)
        {
            Debug.Log(data.ToString());
        }
    }
}
