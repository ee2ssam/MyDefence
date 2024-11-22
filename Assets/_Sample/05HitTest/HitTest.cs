using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    //사각형 데이터를 관리하는 구조체
    public struct BoxData
    {
        public float x;     //box x좌표
        public float y;     //box y좌표
        public float w;     //box width
        public float h;     //box height
    }

    //원 데이터를 관리하는 구조체
    public struct CircleData
    {
        public float x;     //circle x좌표
        public float y;     //circle y좌표
        public float r;     //circle 반지름
    }

    public class HitTest : MonoBehaviour
    {
        //필드
        //타겟
        public Transform _target;

        //이동 속도
        private float moveSpeed = 300;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //이동

            //충돌체크 판정
            if(CheckPassPosition(_target))
            {
                //충돌처리
                Debug.Log("충돌");
            }
        }


        //매개변수로 받은 두개의 box가 충돌했는지 체크
        //충돌하면 true, 충돌하지 않으면 false
        public bool CheckHitBox(BoxData a, BoxData b)
        {
            //충돌하지 않는 4가지 위치 판정
            //1
            if((a.x + a.w/2) < (b.x - b.w/2))
                return false;

            //2
            if ((a.x - a.w / 2) > (b.x + b.w / 2))
                return false;

            //3
            if ((a.y + a.h / 2) > (b.y - b.h / 2))
                return false;

            //4
            if ((a.y - a.h / 2) < (b.y + b.h / 2))
                return false;

            //충돌하지 않는 4가지 위치를 제외한 경우에는 충돌 판정
            return true;
        }

        //매개변수로 받은 두개의 circle이 충돌했는지 체크
        //충돌하면 true, 충돌하지 않으면 false
        public bool CheckHitCircle(CircleData a, CircleData b)
        {
            float distX = a.x - b.x;
            float distY = a.y - b.y;

            float distance = Mathf.Sqrt(distX * distX + distY + distY);

            //두원의 거리가 두원의 반지름의 합보다 작으면 충돌이라고 판정
            if(distance <= (a.r + b.r))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //타겟까지의 거리가 일정 거리안에 있으면 충돌이라고 판정
        private bool CheckArrivePosition(Transform target)
        {
            //타겟까지의 거리
            float distance = Vector3.Distance(this.transform.position, target.position);
            if (distance < 0.5f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //타겟까지 이동할 남은 거리가 이번(한)프레임에 이동하는 거리보다 작을때 충돌이라고 판정
        private bool CheckPassPosition(Transform target)
        {
            //타겟까지 이동할 남은 거리
            float distance = Vector3.Distance(this.transform.position, target.position);
            //이번(한) 프레임에 이동하는 거리
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if(distance < distanceThisFrame)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}