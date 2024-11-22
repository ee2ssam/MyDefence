using UnityEngine;

namespace MyDefence
{
    public abstract class Damageable : MonoBehaviour
    {
        public abstract void TakeDamage(float damage);
    }
}
