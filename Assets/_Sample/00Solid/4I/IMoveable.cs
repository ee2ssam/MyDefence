using UnityEngine;

namespace Solid.Interface
{
    // 이동속도를 가지고 이동 가능한 유닛
    public interface IMoveable
    {
        public float MoveSpeed { get; set; }
        public float Acceleation { get; set; }
        public void GoForward();
        public void GoBack();
        public void TurnLeft();
        public void TurnRight();
    }
}
