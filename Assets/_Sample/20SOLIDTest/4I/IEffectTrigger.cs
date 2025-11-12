using UnityEngine;

namespace Sample
{
    /// <summary>
    /// (VFX, SFX)이펙트 플레이 기능 정의
    /// </summary>
    public interface IEffectTrigger
    {
        public void TriggerEffect(Vector3 position);
    }
}
