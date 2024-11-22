using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sample.ObjectTest;

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        //필드
        //2)
        public Transform publicTransform;
        public GameObject publicObject;

        //3)
        private GameObject[] tagObjects;
        private GameObject tagObject;

        //4)
        public GameObject prefabObejct;

        //5)
        public Transform parentObject;
        private Transform[] childObjects;


        // Start is called before the first frame update
        void Start()
        {
            //1)
            //this.gameObject
            //this.transform

            //2)
            //publicTransform
            //publicObject

            //3)
            //tagObjects = GameObject.FindGameObjectsWithTag("tagString");
            //tagObject = GameObject.FindGameObjectWithTag("tagString");

            //4)
            //GameObject prefabGo = Instantiate(prefabObejct, this.transform.position, Quaternion.identity);

            //5)
            //childObjects = new Transform[parentObject.childCount];
            //for (int i = 0; i < childObjects.Length; i++)
            //{
            //    childObjects[i] = parentObject.GetChild(i);
            //}

            //6)
            //StaticClass.number = 10;

            //Singleton
            //Singleton singleton = new Singleton();
            //Debug.Log(singleton.ToString());

            var objectA = Singleton.Instance;
            var objectB = Singleton.Instance;
            if (objectA == objectB)
            {
                Debug.Log(objectA);
            }

            //SingletonTest.Instance.number = 10;
        }
    }
}


/*
(하이라키창에 있는)게임오브젝트의 gameobject, transform 접근하는 방법,
gameobject, transform의 객체를 가져오는 방법

1) gameobject에 스크립트 소스를 컴포넌트로 추가하여 직접(this) 가져온다
2) 가져오려는 오브젝트의 gameobject, transform 객체(인스턴스)를 public 한 필드로 선언한 후
유니티 에디터 툴의 인스펙터 창으로 직접 드래그 해서 가져온다
3) Find - 유니티에서 제공하는 API를 이용하여 gameobject, transform의 객체를 반환받아 가져온다
, GameObject.FindGameObjectsWithTag, GameObject.FindGameObjectWithTag
4) prefab 게임오브젝트 생성시 Instantiate 함수의 반환값으로 gameobject의 객체를 가져온다
5) 부모 자식관계를 이용해서 게임 gameobject의 객체를 가져온다
6) static 필드: 클래스이름.필드이름, 싱글톤

*/
