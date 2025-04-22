using UnityEngine;

namespace Solid.Interface
{
    //유닛의 모든 기능을 정의 - X
    public interface IUnitStats
    {
        public float Health { get; set; }
        public int Defense { get; set; }
        public void TakeDamage(float damage);
        public void Die();
        public void RestoreHealth(float amount);
        public float MoveSpeed { get; set; }
        public float Acceleation { get; set; }
        public void GoForward();
        public void GoBack();
        public void TurnLeft();
        public void TurnRight();
        public int Strength { get; set; }
        public int Dexterrty { get; set; }
        public int Endurance { get; set; }

    }
}