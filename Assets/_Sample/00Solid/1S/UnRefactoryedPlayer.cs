using UnityEngine;

namespace Solid
{
    //플레이를 관리하는 클래스 : 인풋, 이동, 사운드, 이펙트
    public class UnRefactoryedPlayer : MonoBehaviour
    {
        //이동
        private Vector3 inputVector;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            Move(inputVector);

            //사운드, 이펙트 플레이
        }

        //플레이어 인풋 처리
        private void HandleInput()
        {
            //인풋 기능 구현
        }

        //플레이어의 이동
        private void Move(Vector3 inputVector)
        {
            //이동 기능 구현
        }

        //플레이어 사운드
        private void PlayRandomAuidoClip()
        {
            //사운드 플레이
        }

        //플레이어 이펙트
        private void PlayEffect()
        {
            //이펙트 플레이
        }

    }
}