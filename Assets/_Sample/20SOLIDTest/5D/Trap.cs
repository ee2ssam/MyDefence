using UnityEngine;

namespace Sample
{
    public class Trap : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Activate()
        {
            throw new System.NotImplementedException();
        }

        public void Deactivate()
        {
            throw new System.NotImplementedException();
        }
    }
}