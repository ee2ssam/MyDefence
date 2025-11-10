using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Enemy의 이동을 관리하는 클래스
    /// </summary>
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables
        //이동 목표 위치를 가지고 있는 오브젝트
        private Transform target;

        //이동 속도
        [SerializeField]
        private float speed = 10f;

        //이동속도 초기화
        [SerializeField]
        private float startSpeed = 4f;

        //이동 웨이포인트 인덱스
        private int wayPointIndex = 0;
        #endregion

        #region Property
        public float Speed
        {
            get { return speed; } 
            set { speed = value; }
        }

        public float StartSpeed
        {
            get { return startSpeed; }
        }
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화            
            speed = startSpeed;
            wayPointIndex = 0;

            //이동 목표지점 0번으로 설정
            target = WayPoints.points[wayPointIndex];
        }

        // Update is called once per frame
        void Update()
        {
            //타겟을 향해 이동
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * speed);

            //도착 판정
            //타겟과 Eenmy와 거리를 구해서 일정거리안에 들어오면 도착이라고 판정한다
            float distance = Vector3.Distance(target.position, this.transform.position);
            if (distance <= 0.1f)
            {
                SetNextTarget();
                //Arrive();
            }

            //이동속도 초기 속도로 복원
            speed = startSpeed;
        }
        #endregion

        #region Custom Method
        //다음 타겟 설정
        private void SetNextTarget()
        {
            //종점 체크
            if (wayPointIndex >= WayPoints.points.Length - 1)
            {
                //Debug.Log("종점 도착");
                Arrive();
                return;
            }

            wayPointIndex++;
            target = WayPoints.points[wayPointIndex];
        }

        //종점 도착
        private void Arrive()
        {
            //생명 사용
            PlayerStats.UseLives(1);

            //살아 있는 적의 수를 줄인다
            WaveSpawnManager.enemyAlive--;

            //Enemy 킬
            Destroy(this.gameObject);
        }

        //이동속도 느리게 하기
        public void Slow(float rate)    //40%
        {
            speed = startSpeed * (1 - rate);       //4 * (1 - 0.4) = 2.4
        }
        #endregion
    }
}
