using UnityEngine;

namespace Sample
{
    public class SDoor : MonoBehaviour, ISwitchable
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
