using Solid.Dependency;
using UnityEngine;

namespace Solid
{
    public class Switch : MonoBehaviour
    {
        //public Door door;
        //public Robot robot;1
        public Transform switchTranform;
        private ISwitchable client;  //Door, Robot

        private void Start()
        {
            client = switchTranform.GetComponent<ISwitchable>();
            Debug.Log(client);
        }


        //한번 누르면 문열리고 다시 한번 누르면 문이 닫힌다
        public void Toggle()
        {
            if (client.IsActive)
            {
                client.Deactivate();
            }
            else
            {
                client.Activate();
            }
        }
    }
}
