using UnityEngine;

namespace Solid
{
    public class Door : MonoBehaviour, ISwitchable
    {
        private bool isActive;
        public bool IsActive => isActive;

        public void Activate()
        {
            isActive = true;
            Debug.Log("문이 열린다");
        }

        public void Deactivate()
        {
            isActive = false;
            Debug.Log("문이 닫힌다");
        }
    }
}
