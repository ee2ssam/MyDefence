using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        //필드
        //float x = 0f;

        //회전 속도
        public float turnSpeed = 5f;

        //타겟
        public Transform target;


        // Start is called before the first frame update
        void Start()
        {
            //y축 회전
            //this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            //x축 회전
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            //z축 회전
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        // Update is called once per frame
        void Update()
        {
            //x -= 1;
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f);
            //this.transform.rotation = Quaternion.Euler(x, 0f, 0f);
            //this.transform.rotation = Quaternion.Euler(0, 0f, x);

            //Rotate
            //this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed); // 0, turnSpeed, 0
            //this.transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed); // 0, turnSpeed, 0
            //this.transform.Rotate(Vector3.forward * Time.deltaTime * turnSpeed); // 0, turnSpeed, 0

            //RotateAround - 지구의 공전
            //transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);

            //타겟을 바라보는 회전값 구하기
            //방향구하기
            Vector3 dir = target.position - transform.position;
            //방향 백터로 부터 회전값 얻어오기
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            //transform.rotation = lookRotation; //한번에 이동

            //시작 : transform.rotation
            //종점 : lookRotation
            Quaternion qRotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
            //qRotation에서 Eulerangle 값 얻어오기
            Vector3 eRotation = qRotation.eulerAngles;
            //y축 값만 적용
            transform.rotation = Quaternion.Euler(0f, eRotation.y, 0f);

            //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

        }
    }
}


/*
Lerp(a, b, t)
a=0, b=10
c = Lerp(a, b, 0.1) // 1
c = Lerp(a, b, 0.2) // 2
c = Lerp(a, b, 0.3) // 3
....
c = Lerp(a, b, 0.8) // 8
c = Lerp(a, b, 0.9) // 9
c = Lerp(a, b, 1) // 10

//
a=0, b=10
a = Lerp(0, 10, 0.1) // 1
a = Lerp(a=1, 10, 0.1) // 1.9
a = Lerp(a=1.9, 10, 0.1) // 2.71
*/