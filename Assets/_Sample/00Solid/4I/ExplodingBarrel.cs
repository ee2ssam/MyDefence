using UnityEngine;

namespace Solid.Interface
{
    //폭발하는 통 : Health를 가지고 데미지를 입는다, 폭발 기능을 가지고 있다
    public class ExplodingBarrel : MonoBehaviour, IDamageable, IExplodable
    {
        public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Defense { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float Mass { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float ExplosiveForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float FuseDelay { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void Explode()
        {
            throw new System.NotImplementedException();
        }

        public void RestoreHealth(float amount)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
