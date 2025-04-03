using UnityEngine;

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        //(2) 스크립트의 필드 선언부에서 Transform, GameObject의 객체(인스턴스)를 public으로
        //    선언한 후 유니티툴의 인스펙터 창에서 직접 게임 오브젝트를 연결한다
        public Transform publicTransform;
        public GameObject publicObject;

        //(3) 게임오브젝트의 tag를 이용하여 GameObject의 객체(인스턴스) 가져오기
        private GameObject[] tagObejcts;
        private GameObject tagObject;

        //(4) 프리팹 게임오브젝트 생성시 Instantiate 함수의 반환값으로 GameObject의 객체(인스턴스) 가져오기
        public GameObject gameobjectPrefab;

        //(5) 같은 종류, 기능들로 묶어서 게임 오브젝트들의 객체(인스턴스) 가져오기
        //부모 게임 오브젝트를 만들어서 묶은 다음 부모 오브젝트에 접근하여 자식 오브젝트들의 객체를 가져온다
        public Transform parentObject;
        private Transform[] childObjects;

        //(6) static, 싱글톤 패턴 디자인으로 게임 오브젝트들의 객체(인스턴스) 가져오기
        private SingletonTest singletonTest;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //(1) 게임오브젝트에 스크립트 소스를 컴포넌트롤 추가하여 직접(this.) 가져온다
            //this.transform
            //this.gameObject
            //this.gameObject.transform
            //this.transform.gameObject

            //(2)
            //publicTransform
            //publicObject

            //(3) FindGameObjectsWithTag(), FindGameObjectWithTag() 반환값으로
            // 게임오브젝트의 객체를 가져온다
            //tagObejcts = GameObject.FindGameObjectsWithTag("tagString");
            //tagObject = GameObject.FindGameObjectWithTag("tagString");

            //(4) Instantiate(프리팹오브젝트, 생성위치, 생성회전값) 의 반환값으로
            // 게임오브젝트의 객체를 가져온다
            //GameObject prefabGo = Instantiate(gameobjectPrefab, this.transform.position, Quaternion.identity);

            //(5) parentObject.childCount, parentObject.GetChild 반환값으로 
            // 자식 게임오브젝트들의 객체를 가져온다
            //childObjects = new Transform[parentObject.childCount];
            //for (int i = 0; i < childObjects.Length; i++)
            //{
            //    childObjects[i] = parentObject.GetChild(i);
            //}

            //(6) 싱글톤 패턴 디자인 : 클래스이름.객체이름 으로 접근하여 사용
            //SingletonTest.Instance
            //SingletonTest.Instance.number = 10;
            //singletonTest = SingletonTest.Instance;
            //singletonTest.number = 10;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


/*
(하이라키창에 있는) 게임오브젝트의 gameobject, transform 에 접근하는 방법
게임오브젝트의 GameObject, Transform 클래스의 객체를 가져오는 방법

1) 게임오브젝트에 스크립트 소스를 컴포넌트롤 추가하여 직접(this.) 가져온다
2) 스크립트의 필드 선언부에서 Transform, GameObject의 객체(인스턴스)를 public으로
   선언한 후 유니티툴의 인스펙터 창에서 직접 게임 오브젝트를 연결한다
3) 게임오브젝트의 tag를 이용하여 GameObject의 객체(인스턴스) 가져오기
   FindGameObjectsWithTag(), FindGameObjectWithTag() 반환값 받아오기
4) 프리팹 게임오브젝트 생성시 Instantiate() 함수의 반환값으로 
   GameObject의 객체(인스턴스) 가져오기
5) 같은 종류, 기능들로 묶어서 게임 오브젝트들의 객체(인스턴스) 가져오기
   부모 게임 오브젝트를 만들어서 묶은 다음 부모 오브젝트에 접근하여 자식 오브젝트들의 객체를 가져온다
   parentObject.childCount, parentObject.GetChild 반환값으로 가져오기
6) static : 싱글톤 패턴 디자인을 이용하여 게임 오브젝트 객체(인스턴스 가져오기)
   클래스이름.인스턴스이름, 클래스이름.Instance
*/