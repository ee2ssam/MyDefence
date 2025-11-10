using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 리펙토링 이전의 플레이어 관리하는 클래스
    /// </summary>
    public class UnrefactoredPlayer : MonoBehaviour
    {
        private Vector2 inputVector;

        private void Start()
        {
            
        }

        private void Update()
        {
            HandleInput();
            Move(inputVector);
        }

        void HandleInput()
        {
            //inputVector =
        }

        void Move(Vector2 inputVector)
        {

        }

        void PlayRandomAudioClip()
        {

        }

        void PlayEffect()
        {

        }
    }
}
