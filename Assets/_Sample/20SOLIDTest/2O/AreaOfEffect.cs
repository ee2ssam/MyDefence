using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 이펙트 연출하는 추상 클래스
    /// 이펙트 플레이 영역을 구하는 기능
    /// </summary>
    public abstract class AreaOfEffect : MonoBehaviour
    {
        //추상 메서드 - 영역 계산
        public abstract float CalculateArea();

        //영역 계산 결과값
        public float TotalArea => CalculateArea();

        public void PlayEffect() { }

        public void PayParticleEffect() { }

        public void PlaySoundEffect() { }

        public void ShowAreaText() { }

    }
}
