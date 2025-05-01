using UnityEngine;
using System.Collections;

namespace Sample
{
    public class TorchFlameAnimation : MonoBehaviour
    {
        #region Variables
        //라이트 레거시 애니메이션
        public Animation animation;

        //애니메이션 타이머
        [SerializeField] private float animTimer = 1f;
        private float countdown = 0f;
        //애니메이션 모드
        private int lightMode;
        #endregion

        private void Start()
        {
            //초기화
            lightMode = 0;

            //1초마다 반복 호출
            //InvokeRepeating("FlameAnimation", 0f, 1f);
        }

        private void Update()
        {
            //1초 타이머
            /*countdown += Time.deltaTime;
            if(countdown >= animTimer)
            {
                //타이머 기능 호출
                FlameAnimation();

                //타이머 초기화
                countdown = 0f;
            }*/

            //코루틴으로 타이머 돌리기
            if(lightMode == 0)
            {
                StartCoroutine(LightAnimation());
            }
        }


        //세개중에 하나를 랜덤하게 애니메이션을  플레이
        void FlameAnimation()
        {
            lightMode = Random.Range(1, 4); //1, 2, 3

            switch(lightMode)
            {
                case 1:
                    animation.Play("FlameAnim01");
                    break;
                case 2:
                    animation.Play("FlameAnim02");
                    break;
                case 3:
                    animation.Play("FlameAnim03");
                    break;
            }
        }

        IEnumerator LightAnimation()
        {
            lightMode = Random.Range(1, 4); //1, 2, 3

            switch (lightMode)
            {
                case 1:
                    animation.Play("FlameAnim01");
                    break;
                case 2:
                    animation.Play("FlameAnim02");
                    break;
                case 3:
                    animation.Play("FlameAnim03");
                    break;
            }

            //0.99초 대기
            yield return new WaitForSeconds(0.99f);
            lightMode = 0;
        }

    }
}
