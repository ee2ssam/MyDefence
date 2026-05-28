using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Enemy(적)을 관리하는 클래스
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        //필드 선언부
        #region Variables
        //이동 목표 위치를 가지고 있는 오브젝트
        private Transform target;

        //Enemy 이동 속도
        public float speed = 10f;
        #endregion

        //유니티 이벤트 함수 구현부
        #region Unity Event Method
        private void Start()
        {            
            //타겟(이동 목적지) 찾아오기
            target = GameObject.FindGameObjectWithTag("End").transform;
        }

        private void Update()
        {
            //타겟을 향해 이동 (dir(방향), Time.deltaTime, speed)
            //이동 방향 구하기 : 목표지점 - 현재지점, 도착 예정위치 - 출발(현재) 위치
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

            //도착 판정
            //타겟과 enemy와의 거리를 구해서 일정거리(0.2f) 안에 들어오면 도착이라고 판정한다
            float distance = Vector3.Distance(target.position, this.transform.position);
            if(distance <= 0.2f)
            {
                ArriveAtTarget();
            }

        }
        #endregion

        //유저 구현 함수
        #region Custom Method
        //Enemy가 타겟에 도착시 처리 내용 구현
        void ArriveAtTarget()
        {
            //Debug.Log("타겟에 도착 했다");
            Destroy(this.gameObject);
        }
        #endregion
    }
}