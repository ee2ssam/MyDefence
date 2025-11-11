using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 도로위에 탈것을 구현한 클래스
    /// </summary>
    public class RoadVehicle : MonoBehaviour, IMoveable, ITurnable
    {
        public float moveSpeed;
        public float turnSpeed;

        public void GoBack()
        {
            throw new System.NotImplementedException();
        }

        public void GoForward()
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