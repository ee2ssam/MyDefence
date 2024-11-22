using UnityEngine;

namespace MyDefence
{
    //Enemy의 이동을 관리하는 클래스
    public class EnemyMove : MonoBehaviour
    {
        //필드
        #region Variable
        [SerializeField] private float speed;   //이동 속도
        [SerializeField] private float startSpeed = 3f; //이동 시작 속도

        private Transform target;   //이동할 목표지점        

        private int wayPointIndex = 0;  //wayPoints 배열을 관리하는 인덱스
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //초기화
            speed = startSpeed;

            //첫번째 목표지점 셋팅
            wayPointIndex = 0;
            target = WayPoints.points[wayPointIndex];
        }

        private void Update()
        {
            Move();

            //속도 복원
            speed = startSpeed;
        }

        //이동
        public void Move()
        {
            //이동 :방향(dir), Time.deltatiem, speed
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed);

            //도착판정
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 0.2f)
            {
                SetNextTarget();
            }
        }

        //다음 목표 지점 셋팅
        void SetNextTarget()
        {
            if (wayPointIndex == WayPoints.points.Length - 1)
            {
                Arrive();
                return;
            }

            wayPointIndex++;
            target = WayPoints.points[wayPointIndex];
        }

        //목표지점 도착 처리
        void Arrive()
        {
            //Debug.Log("종점 도착");
            PlayerStats.UseLives(1);

            //살아있는 적 카운팅
            SpawnManager.enmeyAlive--;

            //게임 오브젝트 kill
            Destroy(this.gameObject);
            //
            //Debug.Log("과금");
            //isPaid = true;
        }

        public void Slow(float rate)
        {
            speed = startSpeed * (1.0f - rate);
        }

    }
}