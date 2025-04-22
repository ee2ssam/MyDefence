using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    public class Enemy : MonoBehaviour
    {
        //필드
        #region Field
        //체력
        private float health;

        //체력 초기값
        [SerializeField] private float startHealth = 100f;

        //죽음 체크
        private bool isDeath = false;

        //도착 체크
        private bool isArrive = false;

        //이동 속도
        public float moveSpeed = 5f;

        //이동 속도 - origin
        private float startMoveSpeed;

        //wayPoint 오브젝트의 트랜스폼 객체
        private Transform target;
        //wayPoints 배열의 인덱스
        private int wayPointIndex = 0;

        //리워드 골드
        [SerializeField] private int rewardGold = 50;

        //죽음 이펙트 프리팹
        public GameObject deathEffectPrefab;

        //Health Bar UI
        public Image healthBarImage;
        #endregion

        #region Property
        public bool IsArrive
        {
            get { return isArrive; }
        }
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            wayPointIndex = 0;
            target = WayPoints.wayPoints[wayPointIndex];
            health = startHealth;
            startMoveSpeed = moveSpeed;
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
            if(distance <= 0.1f)
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
            if(wayPointIndex == WayPoints.wayPoints.Length - 1)
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

        //데미지 처리
        public void TakeDamage(float damage)
        {
            if (isArrive)
                return;

            //연산
            health -= damage;
            
            //health bar 적용
            //health : 0->100(startHealth), fillamunt 0->1 (100%, 소수점, 분수)
            //백분율: (현재값량: health) / (총값량:100) startHealth
            healthBarImage.fillAmount = health / startHealth;

            //데미지 효과(VFX, SFX)

            //죽음 체크, 두번 죽는것 체크
            if (health <= 0f && isDeath == false)
            {
                Die();
            }
        }

        //죽음 처리
        private void Die()
        {
            //죽음 체크
            isDeath = true;

            //보상, 벌
            //리워드로 50 Gold 지급
            PlayerStats.AddMoney(rewardGold);

            //VFX, SFX
            //죽는 파티클 이펙트 만들어서 처리
            GameObject effectGo = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //Enemy 카운팅
            WaveManager.enemyAlive--;
            Debug.Log($"enemyAlive: {WaveManager.enemyAlive}");

            //킬
            Destroy(this.gameObject, 0f);
        }

        //매개변수로 입력받은 감속률 만큼 속도 감속
        public void Slow(float rate)
        {
            moveSpeed = startMoveSpeed * (1-rate);
        }

    }
}