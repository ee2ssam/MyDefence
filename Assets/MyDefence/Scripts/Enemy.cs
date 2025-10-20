using UnityEngine;
using UnityEngine.Rendering;

namespace MyDefence
{
    /// <summary>
    /// Enemy 를 관리하는 클래스
    /// </summary>
    public class Enemy : MonoBehaviour, IDamageable
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

        //체력
        private float health;

        [SerializeField]
        private float startHealth = 100f;    //체력 초기값

        //죽음 체크
        private bool isDeath = false;

        //죽음 효과
        public GameObject deathEffectPrefab;

        //죽음 보상
        [SerializeField]
        private int rewardMoney = 50;
        #endregion


        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            health = startHealth;
            speed = startSpeed;

            target = WayPoints.points[0];
        }

        // Update is called once per frame
        void Update()
        {
            //타겟을 향해 이동
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * speed);

            //도착 판정
            //타겟과 Eenmy와 거리를 구해서 일정거리안에 들어오면 도착이라고 판정한다
            float distance =  Vector3.Distance(target.position, this.transform.position);
            if(distance <= 0.5f)
            {
                Arrive();
            }

            //이동속도 초기 속도로 복원
            speed = startSpeed;
        }
        #endregion

        #region Custom Method
        //종점 도착
        private void Arrive()
        {
            //생명 사용
            PlayerStats.UseLives(1);

            //Enemy 킬
            Destroy(this.gameObject);
        }

        //매개변수로 들어온 만큼 데미지를 입는다
        public void TakeDamage(float damage)
        {
            health -= damage;
            //Debug.Log($"Enemy Health: {health}");

            //죽음 체크
            if(health <= 0 && isDeath == false)
            {
                health = 0;
                Die();
            }
        }

        //죽음 처리
        private void Die()
        {
            //죽음 체크
            isDeath = true;

            //죽음 처리...
            //effct 효과 (vfx, sfx)
            GameObject effectGo = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //보상 처리(골드, 경험치, 아이템..)
            PlayerStats.AddMoney(rewardMoney);

            //Enemy Kill
            Destroy(this.gameObject);
        }

        //이동속도 느리게 하기
        public void Slow(float rate)    //40%
        {
            speed = startSpeed * (1 - rate);       //4 * (1 - 0.4) = 2.4
            Debug.Log($"Speed: {speed}");
        }
        #endregion
    }
}