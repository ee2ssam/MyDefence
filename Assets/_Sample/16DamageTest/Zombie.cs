using UnityEngine;
using UnityEngine.Rendering;

namespace Sample
{
    public class Zombie : MonoBehaviour
    {
        #region Variables
        //체력
        private float health;

        [SerializeField]
        private float startHealth = 1f;    //체력 초기값

        //죽음 체크
        private bool isDeath = false;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            health = startHealth;
        }
        #endregion

        #region Custom Method
        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log($"Zombie Health: {health}");

            if (health <= 0 && isDeath == false)
            {
                Die();
            }
        }

        private void Die()
        {
            isDeath = true;

            //
            Destroy(gameObject);
        }
        #endregion
    }
}