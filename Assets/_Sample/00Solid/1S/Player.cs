using UnityEngine;

namespace Solid
{
    //플레이어를 관리하는 클래스
    public class Player : MonoBehaviour
    {
        #region Field
        private PlayerInput m_PlayerInput;
        private PlayerMovement m_PlayerMovement;
        private PlayerAudio m_PlayerAudio;
        private PlayerFX m_PlayerFx;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            m_PlayerInput = this.GetComponent<PlayerInput>();
            m_PlayerMovement = GetComponent<PlayerMovement>();
            m_PlayerAudio = GetComponent<PlayerAudio>();
            m_PlayerFx = GetComponent<PlayerFX>();
        }

        // Update is called once per frame
        void Update()
        {
            //m_PlayerInput.InputHandle();
            //m_PlayerMovement.Move();
        }
    }
}