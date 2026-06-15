using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 라이트 애니메이션 3개중 하나를 1초마다 랜덤하게 플레이 시킨다
    /// Animator의 파라미터(LightMode) 값을 1,2,3중 랜덤하게 셋팅
    /// </summary>
    public class AnimatorTest : MonoBehaviour
    {
        #region Variables
        //Animator 인스턴스 가져오기
        private Animator animator;

        public float aniTimer = 1f;
        public float countdown;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            animator = GetComponent<Animator>();

            //초기화
            countdown = 0f;

            //RandomFlameAnimation() 함수를 1초에 한번씩 호출, 시작은 딜레이 타임 없이
            InvokeRepeating("RandomFlameAnimation", 0f, 1f);
        }

        private void Update()
        {
            //라이트 애니메이션 3개중 하나를 1초마다 랜덤하게 플레이 시킨다
            /*countdown += Time.deltaTime;
            if(countdown >= aniTimer)
            {
                //타이머 기능 - 라이트 애니메이션 3개중 하나를 플레이
                //LightMode 파라미터를 1초마다 랜덤하게 만든다
                RandomFlameAnimation();

                //타이머 초기화
                countdown = 0f;
            }*/
        }
        #endregion

        #region Custom Method
        void RandomFlameAnimation()
        {
            int lightMode = Random.Range(1, 4); //1, 2, 3 랜덤값 얻기
            animator.SetInteger("LightMode", lightMode);
        }
        #endregion

    }
}