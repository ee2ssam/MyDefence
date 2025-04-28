using UnityEngine;

namespace MyDefence
{
    public interface IDamageable
    {
        public void TakeDamage(float damage);
        public void Slow(float rate);
    }
}