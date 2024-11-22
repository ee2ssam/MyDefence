using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private PlayerInput m_PlayerInput;
        private PlayerMovement m_PlayerMovement;
        private PlayerAudio m_PlayerAudio;
        private PlayerFX m_PlayerFX;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            m_PlayerInput = GetComponent<PlayerInput>();
            m_PlayerMovement = GetComponent<PlayerMovement>();
            m_PlayerAudio = GetComponent<PlayerAudio>();
            m_PlayerFX = GetComponent<PlayerFX>();
        }

        // Update is called once per frame
        void Update()
        {
            //m_PlayerInput.InputHandle();
            //m_PlayerMovement.Move();
        }
    }
}