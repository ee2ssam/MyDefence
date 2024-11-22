using UnityEngine;

namespace Sample
{
    public class SSwitch : MonoBehaviour
    {
        //public SDoor sDoor;
        public Transform clientTrans;
        public ISwitchable client;

        void Start()
        {
            client = clientTrans.GetComponent<ISwitchable>();
            Debug.Log(client);
        }

        //한번 호출하면 문이 열리고 다시 호출하면 문이 닫힌다
        public void Toggle()
        {
            if(client.IsActive)
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
