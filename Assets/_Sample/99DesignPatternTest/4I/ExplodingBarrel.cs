using UnityEngine;

namespace Sample
{
    public class ExplodingBarrel : MonoBehaviour, IDamageable, IExplodable
    {
        public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Defense { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float Mass { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float ExplosiveForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float FuseDelay { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Die()
        {
            
        }

        public void Explode()
        {
            
        }

        public void RestoreHealth()
        {
            
        }

        public void TakeDamage()
        {
            
        }
    }
}
