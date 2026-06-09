using UnityEngine;
using System;

namespace MySample
{
    //직렬화된 구조체
    [Serializable]
    public struct TestStruct
    {
        public int value1;
        public float value2;
    }

    /// <summary>
    /// 직렬화 예제
    /// 필드(멤버변수)의 직렬화 : 인스펙터창에서 편집가능하게 한다
    /// </summary>
    public class SerialTest : MonoBehaviour
    {
        //public 직렬화
        public int number = 10;

        //SerializeField 직렬화
        [SerializeField]
        private string name = "Tom";

        //직렬화된(Serializable) 구조체
        public TestStruct testStruct;

    }
}