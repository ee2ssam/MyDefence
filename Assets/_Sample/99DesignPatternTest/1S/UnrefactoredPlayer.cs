using UnityEngine;

namespace Solid
{
    public class UnrefactoredPlayer : MonoBehaviour
    {
        private Vector3 inputVector;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            Move(inputVector);
        }

        //플레이어 인풋기능
        private void HandleInput()
        {
            //...
        }
        //....

        //플레이어 이동
        private void Move(Vector3 inputVector)
        {
            //....
        }
        //....

        //플레이어 사운드
        public void PalyRandomAudioClip()
        {
            //....
        }
        //....

        //플레이어 이펙트
        public void PlayEffect()
        {
            //....
        }
        //....

    }
}
