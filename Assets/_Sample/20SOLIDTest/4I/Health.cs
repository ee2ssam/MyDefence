using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 체력을 가진 오브젝트
    /// </summary>
    public class Health : MonoBehaviour
    {
        public float currentHealth;
        public float maxHealth = 100f;

        protected virtual void Start()
        {
            currentHealth = maxHealth;
        }

        protected virtual void Die()
        {

        }
    }
}