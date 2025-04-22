using UnityEngine;

namespace Solid
{
    public class Robot : MonoBehaviour, ISwitchable
    {
        private bool isActive;
        public bool IsActive => isActive;

        public void Activate()
        {
            isActive = true;
            Debug.Log("로봇이 움직이기 시작한다");
        }

        public void Deactivate()
        {
            isActive = false;
            Debug.Log("로봇이 멈춘다");
        }
    }
}
