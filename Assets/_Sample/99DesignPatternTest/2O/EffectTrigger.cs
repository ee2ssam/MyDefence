using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public class EffectTrigger : MonoBehaviour
    {
        public AreaOfEffect m_Effect;
        //public RectangleEffect rectangleEffect;
        //public CircleEffect circleEffect;
        //

        void Start()
        {
            Debug.Log(m_Effect.CaculateArea().ToString());
        }

        private void OnTriggerEnter(Collider other)
        {
            //이펙트를 터트린다
            PlayEffect(other);
        }

        void PlayEffect(Collider other)
        {
            if(other.tag == "Player")
            {
                //rectangleEffect.PlayEffect();
                //circleEffect.PlayEffect();
                m_Effect.PlayEffect();
            }
        }
    }
}