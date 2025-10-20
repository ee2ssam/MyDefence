using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 전투 가능한 모든 몬스터들의 부모 클래스
    /// </summary>
    public class Monster : MonoBehaviour
    {
        #region Variablse
        //체력
        protected float health;

        [SerializeField]
        protected float startHealth = 100f;    //체력 초기값

        //죽음 체크
        protected bool isDeath = false;
        #endregion

        #region Unity Event Method
        protected virtual void Start()
        {
            //초기화
            health = startHealth;
        }
        #endregion

        #region Custom Method
        public virtual void TakeDamage(float damage)
        {
            health -= damage;

            //죽음 체크
            if(health <= 0f && isDeath == false)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            isDeath = true;

            //kill
            Destroy(gameObject);
        }
        #endregion
    }
}
