using UnityEngine;

namespace MyDefence
{
    public class Monster : MonoBehaviour, IDamageable
    {
        //필드
        #region Variable
        //체력
        private float health;
        [SerializeField] private float startHealth = 100;

        //죽음 효과
        public GameObject deathEffectPrefab;

        //보상 금액
        [SerializeField]
        private int rewardGold = 50;
        #endregion

        private void Start()
        {
            //초기화
            health = startHealth;
        }

        //데미지 처리
        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log($"health: {health}");

            if (health <= 0)
            {
                Die();
            }
        }

        //죽음 처리
        void Die()
        {
            //죽는 파티클 이펙트 처리
            GameObject effectGo = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //리워드로 50 Gold 지급
            PlayerStats.AddMoney(rewardGold);

            //kill
            Destroy(gameObject);
        }
    }
}
