using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 도형 모양의 트리거 오브젝트
    /// </summary>
    public class EffectTrigger : MonoBehaviour
    {
        public AreaOfEffect areaOfEffect;   //원, 사각, ..

        private void OnTriggerEnter(Collider other)
        {
            PlayEffect(other);
        }

        void PlayEffect(Collider collider)
        {
            if(collider.tag == "Payer")
            {
                areaOfEffect.PlayEffect();
                areaOfEffect.PlaySoundEffect();
            }
        }
    }
}
