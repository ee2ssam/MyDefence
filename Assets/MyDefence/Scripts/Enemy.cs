using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    /// <summary>
    /// Enemy의 체력을 관리하는 클래스
    /// </summary>
    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables
        //참조
        private EnemyMovement enemyMovement;

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

        //UI
        public Image hpBarImage;
        #endregion


        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            enemyMovement = this.GetComponent<EnemyMovement>();

            //초기화
            health = startHealth;            
        }
        #endregion

        #region Custom Method        
        //매개변수로 들어온 만큼 데미지를 입는다
        public void TakeDamage(float damage)
        {
            health -= damage;
            //Debug.Log($"Enemy Health: {health}");

            //UI
            hpBarImage.fillAmount = health / startHealth;

            //죽음 체크
            if (health <= 0 && isDeath == false)
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

            //살아 있는 적의 수를 줄인다
            WaveSpawnManager.enemyAlive--;

            //보상 처리(골드, 경험치, 아이템..)
            PlayerStats.AddMoney(rewardMoney);

            //Enemy Kill
            Destroy(this.gameObject);
        }

        //이동속도 느리게 하기
        public void Slow(float rate)    //40%
        {
            enemyMovement.Speed = enemyMovement.StartSpeed * (1 - rate);       //4 * (1 - 0.4) = 2.4
        }
        #endregion
    }
}