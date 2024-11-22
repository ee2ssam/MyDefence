using UnityEngine;

namespace Sample
{
    public class EnemyUnit : MonoBehaviour, IDamageable, IMovable, IStats
    {
        public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Defense { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float MoveSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float Acceleration { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Strength { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Dexterrty { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Endurance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void GoBack()
        {
            throw new System.NotImplementedException();
        }

        public void GoForward()
        {
            throw new System.NotImplementedException();
        }

        public void RestoreHealth()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage()
        {
            throw new System.NotImplementedException();
        }

        public void TurnLeft()
        {
            throw new System.NotImplementedException();
        }

        public void TurnRight()
        {
            throw new System.NotImplementedException();
        }
    }
}
