using UnityEngine;

namespace Sample
{
    //사각형 구조체
    struct cBox
    {
        public float x;     //x좌표
        public float y;     //y좌표
        public float w;     //width
        public float h;     //height
    }

    //원 구조체
    struct cCircle
    {
        public float x;     //x좌표
        public float y;     //y좌표
        public float r;     //반지름
    }


    public class HitTest : MonoBehaviour
    {
        #region Variables
        public float moveSpeed = 10f;
        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //매개변수로 받은 두개의 box가 충돌했는지 체크
        //충돌했으면 true, 충돌하지 않았으면 false 반환
        private bool CheckHitBox(cBox a, cBox b)
        {
            float xDistance = (a.x < b.x) ? (b.x - a.x) : (a.x - b.x);
            float yDistance = (a.y < b.y) ? (b.y - a.y) : (a.y - b.y);

            if ((a.w / 2 + b.w / 2) >= xDistance && (a.h / 2 + b.h / 2) >= yDistance)
            {
                return true;
            }

            return false;
        }

        //매개변수로 받은 두개의 circle이 충돌했는지 체크
        //충돌했으면 true, 충돌하지 않았으면 false 반환
        private bool CheckHitCircle(cCircle a, cCircle b)
        {
            float xDistance = a.x - b.x;
            float yDistance = a.y - b.y;

            float distance = Mathf.Sqrt(xDistance * xDistance + yDistance * yDistance);

            //두원 사이의 거리가 두원의 반지름의 합보다 작으면 충돌이라고 판정
            if(distance <= (a.r + b.r))
            {
                return true;
            }

            return false;
        }

        //도착 판정으로 충돌체크
        //두 오브젝트의 거리가 일정거리(0.5f)안에 있으면 충돌이라 판정
        private bool CheckArrivePosition(Transform target)
        {
            float distance = Vector3.Distance(this.transform.position, target.position);

            if(distance < 0.5f)
            {
                return true;
            }

            return false;
        }

        //이동시 타겟까지의 남은 거리가 한 프레임 동안 이동하는 거리보다 작을때 충돌이라고 판정
        private bool CheckPassPosition(Transform target)
        {
            //남은 거리
            float distance = Vector3.Distance(this.transform.position, target.position);
            //한 프레임마다 이동하는 거리
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if (distance <= distanceThisFrame)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}