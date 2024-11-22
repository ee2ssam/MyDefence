using UnityEngine;

namespace Sample
{
    [System.Serializable]
    public struct TestStruct
    {
        public int value1;
        public float value2;
    }

    public class SerializationTest : MonoBehaviour
    {
        /*public int speed = 10;
        [SerializeField]
        private float attackRange = 7f;

        public TestStruct testStruct;  */      
    }
}

/*
Unity에서 직렬화를 사용하면 인스펙터 창에서 편집 가능하게 할 수 있다

저장 및 로드
인스펙터창
에디터에서 스크립 재로드
프리팹
인스턴스화
스크립터블 오브젝트
*/
