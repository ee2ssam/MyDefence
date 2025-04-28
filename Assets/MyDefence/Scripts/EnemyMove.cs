using UnityEngine;

namespace MyDefence
{
    // 적의 이동을 관리하는 클래스
    public class EnemyMove : MonoBehaviour
    {
        //필드
        #region Field        
        //도착 체크
        private bool isArrive = false;

        //이동 속도
        [HideInInspector] public float moveSpeed;

        //이동 속도 - origin
        [SerializeField] private float startMoveSpeed = 5f;

        //wayPoint 오브젝트의 트랜스폼 객체
        private Transform target;
        //wayPoints 배열의 인덱스
        private int wayPointIndex = 0;
        #endregion

        #region Property
        //도착 여부 체크
        public bool IsArrive => isArrive;
        public float StartMoveSpeed => startMoveSpeed;        
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            wayPointIndex = 0;
            target = WayPoints.wayPoints[wayPointIndex];
            moveSpeed = startMoveSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if (isArrive)
                return;

            //이동 구현
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //target 도착 판정
            float distance = Vector3.Distance(target.position, this.transform.position);
            if (distance <= 0.1f)
            {
                //다음 타겟 셋팅
                GetNextTarget();
            }

            //속도 원복
            moveSpeed = startMoveSpeed;
        }

        //다음 타겟 얻어오기
        void GetNextTarget()
        {
            //종점 도착 판정
            if (wayPointIndex == WayPoints.wayPoints.Length - 1)
            {
                //종점 도착 체크
                isArrive = true;

                //플레이어의 라이프 소모
                PlayerStats.UseLife(1);

                //Enemy 카운팅
                WaveManager.enemyAlive--;
                Debug.Log($"enemyAlive: {WaveManager.enemyAlive}");

                //공격 VFX, SFX

                Destroy(this.gameObject, 1f);
                return;
            }

            wayPointIndex++;
            target = WayPoints.wayPoints[wayPointIndex];
        }

    }
}
