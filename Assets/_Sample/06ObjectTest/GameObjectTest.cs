using UnityEngine;

/*
(하이라키 창에 있는) 게임오브젝트의 gameobject 또는 transform에 접근 하는 방법
gameobject 또는 transform 인스턴스(객체)를 가져오는 방법

[1] 접근할 게임오브젝트에 직접 스크립트 소스를 컴포넌트로 추가하여 직접(this) 가져온다
[2] 접근할 다른 게임오브젝트의 gameobject, transform 인스턴스(객체) 변수를 public 한 필드로
    선언한 후 인스펙터 창에서 드래그로 직접 가져온다
[3] Find - 유니티에서 제공하는 API를 이용하여 gameobject, transform 인스턴스(객체)를 반환받아
    가져온다 (ex GameObject.FindGameObjectWithTag, GameObject.FindGameObjectsWithTag..)
[4] Prefab 게임오브젝트 생성시 Instantiate 함수의 반환값으로 gameobject 객체를 가져온다
[5] 같은 종류, 같은 기능들로 묶어져 있는 게임오브젝트의 gameobject, transform 인스턴스(객체) 가져오기
    부모 오브젝트를 만들고 같은 종류, 같은 기능가진 오브젝트들을 자식 오브젝트로 추가한다
*/

namespace Sample
{
    public class GameObjectTest : MonoBehaviour
    {
        //[2]gameobject, transform 인스턴스(객체) 변수를 public 한 필드 선언
        public GameObject publicObject;
        public Transform publicTransform;

        //[3] Find API중 tag를 이용하여 gameobject, transform 인스턴스(객체) 가져오기
        private GameObject[] tagObjects;
        private GameObject tagObject;

        //[4] Prefab 게임오브젝트 생성시 Instantiate 함수의 반환값으로 gameobject 객체를 가져온다
        public GameObject gameobjectPrefab;

        
        //[5]부모 오브젝트의 객체를 통해 자식 오브젝트들의 gameobject, transform 인스턴스(객체)에 접근
        public Transform parentObject;
        private Transform[] childObjects;

        //[6] static 성질 이용: 싱글톤 패턴, 
        // static 필드: 클래스이름.필드이름
        //private Singleton singleton;


        private void Start()
        {
            //[1] 직접 스크립트 소스를 컴포넌트로 추가하여 직접(this) 가져온다
            //this.gameObject
            //this.transform
            //this.gameObject.transform
            //this.transform.gameObject

            //[2]
            //publicObject.GetComponent<>()
            //publicTransform.position

            //[3] tag를 이용하여 gameobject, transform 인스턴스(객체) 가져오기
            tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
            tagObject = GameObject.FindGameObjectWithTag("Enemy");

            //[4] Prefab 게임오브젝트 생성시 Instantiate 함수의 반환값으로 gameobject 객체를 가져온다
            GameObject prefabGo = Instantiate(gameobjectPrefab, this.transform.position, Quaternion.identity);

            //[5] 부모와 자식과의 관계를 이용하여 자식 게임오브젝트들의 transform 인스턴스(객체) 가져오기
            // childCount: 자식오브젝트의 갯수, GetChild(index): index번째 자식 인스턴스 반환
            childObjects = new Transform[parentObject.childCount];
            for (int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i] = parentObject.GetChild(i);
            }

        }
    }
}