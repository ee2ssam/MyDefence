using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    //적의 전투(체력, 데미지 처리)를 관리하는 클래스
    public class Enemy : MonoBehaviour, IDamageable
    {
        //필드
        #region Field
        private EnemyMove enemyMove;

        //체력
        private float health;

        //체력 초기값
        [SerializeField] private float startHealth = 100f;

        //죽음 체크
        private bool isDeath = false;

        //리워드 골드
        [SerializeField] private int rewardGold = 50;

        //죽음 이펙트 프리팹
        public GameObject deathEffectPrefab;

        //Health Bar UI
        public Image healthBarImage;
        #endregion

        #region Property
        public bool IsArrive => enemyMove.IsArrive;
        #endregion


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            enemyMove = this.GetComponent<EnemyMove>();

            //초기화
            health = startHealth;            
        }

        //데미지 처리
        public void TakeDamage(float damage)
        {
            if (enemyMove.IsArrive)
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
            enemyMove.moveSpeed = enemyMove.StartMoveSpeed * (1-rate);
        }

    }
}