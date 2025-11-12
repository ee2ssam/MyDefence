using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 온오프 기능을 가진 오브젝트를 관리하는 클래스
    /// </summary>
    public class Switch : MonoBehaviour
    {
        public ISwitchable m_Client;

        public void Toggle()
        {
            if (m_Client == null)
                return;

            if(m_Client.IsActive)
            {
                m_Client.Deactivate();
            }
            else
            {
                m_Client.Activate();
            }
        }
    }
}
