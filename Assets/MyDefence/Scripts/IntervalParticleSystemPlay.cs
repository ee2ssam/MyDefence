using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 일정 시간 간격으로 파티클 이펙트를 플레이 시켜주는 클래스
    /// </summary>
    public class IntervalParticleSystemPlay : MonoBehaviour
    {
        #region Variables
        //연출 파티클
        public ParticleSystem particleToPlay;

        //플레이 타이머
        [SerializeField]
        private float playTimer = 5f;
        private float countdown = 0f;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //일정시간(playTimer)마다 한번씩 지정하는 함수를 호출하라
            InvokeRepeating("PlayParticleSystem", 0f, playTimer);
        }

        private void Update()
        {
            //파티클 플레이 타이머
            /*countdown += Time.deltaTime;
            if(countdown >= playTimer)
            {
                //타이머 기능
                PlayParticleSystem();

                //타이머 초기화
                countdown = 0f;
            }*/
        }
        #endregion

        #region Custom Method
        private void PlayParticleSystem()
        {
            if (particleToPlay == null)
                return;

            particleToPlay.Play();
        }
        #endregion


    }
}