using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class ComponentTest : MonoBehaviour
    {
        //필드
        public float moveSpeed = 5f;

        //타겟
        public Transform target;            //Target 게임오브젝트의 Transform 객체로 접근
        public GameObject gTarget;          //Target 게임오브젝트 객체로 접근
        public TargetTest cTarget;          //TargetTest에 직접 접근

        // Start is called before the first frame update
        void Start()
        {
            //문법 TargetTest 객체 생성
            //TargetTest tTest = new TargetTest();
            //tTest.b = 30;

            //target 게임 오브젝트의 트랜스폼에 붙어있는 TargetTest의 객체에 접근
            //TargetTest tTest = target.GetComponent<TargetTest>();
            //tTest.b = 30;   //public한 필드를 가져와 사용
            //Debug.Log(tTest.GetA()); //private a를 public한 메서드로 접근해서 사용

            //target 게임 오브젝트에 붙어있는 TargetTest의 객체에 접근
            //TargetTest gTest = gTarget.GetComponent<TargetTest>();
            //gTest.b = 50;   //public한 필드를 가져와 사용
            //Debug.Log(gTest.GetA()); //private a를 public한 메서드로 접근해서 사용

            //Target 게임 오브젝트에 붙어있는 TargetTest의 객체에 직접 접근
            cTarget.b = 70;
            Debug.Log(cTarget.GetA());
            //cTarget.transform.GetComponent<>

            //플레이어
            //ComponentTest 스크립트가 붙어있는 게임 오브젝트의 트랜스폼 객체
            //this.transform
            //this.transform.GetComponent<>
            //ComponentTest 스크립트가 붙어있는 게임 오브젝트 객체
            //this.gameObject
            //this.gameObject.GetComponent<>
            //this.transform.gameObject
            //this.gameObject.transform
        }

        // Update is called once per frame
        void Update()
        {
            //타겟으로 이동
            // 방향 * Time.deltaTime * 속도
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        }
    }
}