using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 지정된 시간마다 반복적으로 파티클 이펙트 플레이 시켜주는 클래스
    /// </summary>
    public class IntervalParticlePlay : MonoBehaviour
    {
        //플레이 할파티클 이펙트 인스턴스
        public ParticleSystem particleEffect;

        //인터벌 타임
        [SerializeField]
        private float playTimer = 5f;
        //시작 딜레이
        [SerializeField]
        private float delayTime = 0f;

        private void Start()
        {
            //반복 실행
            InvokeRepeating("PlayParticleSystem", delayTime, playTimer);
        }

        void PlayParticleSystem()
        {
            //null 체크
            if (particleEffect == null)
                return;

            particleEffect.Play();
        }

    }
}