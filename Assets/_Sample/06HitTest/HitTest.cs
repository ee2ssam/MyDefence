using Unity.Mathematics;
using UnityEngine;

namespace MySample
{
    //사각형을 정보를 관리하는 구조체
    public struct CBox
    {
        public float x; //x 좌표
        public float y; //y 좌표
        public float w; //Width
        public float h; //Height
    }

    //원의 정보를 관리하는 구조체
    public struct CCircle
    {
        public float x;
        public float y;
        public float r; //반지름
    }

    /// <summary>
    /// 충돌 테스트 예제
    /// </summary>
    public class HitTest : MonoBehaviour
    {
        #region Custom Method
        //매개변수로 받은 두개의 Box가 충돌했는지 체크하는 함수
        //충돌했으면 true 반환, 충돌하지 않았으면 false 반환
        public bool CheckHitBox(CBox a, CBox b)
        {
            float xDistance = (a.x < b.x) ? (b.x - a.x) : (a.x - b.x);
            float yDistance = (a.y < b.y) ? (b.y - a.y) : (a.y - b.y);

            if(xDistance <= (a.w/2 + b.w/2) && yDistance <= (a.h/2 + b.h/2))
            {
                return true;
            }

            return false;
        }

        //매개변수로 받은 두개의 Circle이 충돌했는지 체크하는 함수
        //충돌했으면 true 반환, 충돌하지 않았으면 false 반환
        public bool CheckHitCircle(CCircle a, CCircle b)
        {
            float xDistance = (a.x < b.x) ? (b.x - a.x) : (a.x - b.x);
            float yDistance = (a.y < b.y) ? (b.y - a.y) : (a.y - b.y);
            //두 원 중점간의 거리
            float distance = Mathf.Sqrt(xDistance * xDistance + yDistance * yDistance);

            if(distance <= (a.r + b.r))
            {
                return true;
            }

            return false;
        }

        //도착 판정으로 충돌체크
        //두 오브젝트 간의 거리가 일정거리(0.5f)안에 있으면 충돌이라고 판정
        //충돌했으면 true 반환, 충돌하지 않았으면 false 반환
        public bool CheckArrivePosition(Transform target)
        {
            float distance = Vector3.Distance(this.transform.position, target.position);
            if(distance < 0.5f)
            {
                return true;
            }

            return false;
        }

        //이동시 타겟까지 남은거리와 이번 프레임에 이동거리를 비교하여 충돌판정
        public float moveSpeed = 10f;
        public bool CheckPassPosition(Transform target)
        {
            //남은거리
            float distance = Vector3.Distance(this.transform.position, target.position);
            //이번 프레임에 이동하는 거리
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if(distance <= distanceThisFrame)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}