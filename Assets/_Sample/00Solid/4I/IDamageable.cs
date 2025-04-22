using UnityEngine;

namespace Solid.Interface
{
    // health을 가지고 전투하는 unit
    public interface IDamageable
    {
        public float Health { get; set; }
        public int Defense { get; set; }
        public void TakeDamage(float damage);
        public void Die();
        public void RestoreHealth(float amount);
    }
}