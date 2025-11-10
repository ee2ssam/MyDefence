using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 플레이어를 관리하는 클래스
    /// </summary>
    public class Player : MonoBehaviour
    {
        //참조
        private PlayerMovement playerMovement;
        private PlayerInput playerInput;
        private PlayerAudio playerAudio;
        private PlayerVFX playerVFX;

        private void Awake()
        {
            Initialize();
        }

        //플레이어 초기화 함수
        private void Initialize()
        {
            //참조
            playerMovement = this.GetComponent<PlayerMovement>();
            playerInput = this.GetComponent<PlayerInput>();
            playerAudio = this.GetComponent<PlayerAudio>();
            playerVFX = this.GetComponent<PlayerVFX>();

        }


    }
}