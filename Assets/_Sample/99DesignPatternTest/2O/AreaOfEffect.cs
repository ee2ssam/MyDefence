using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public abstract class AreaOfEffect : MonoBehaviour
    {
        public float TotalArea => CaculateArea();
        public abstract float CaculateArea();

        public void PlayEffect()
        {
            //...
        }

        public void PlayParticleEffect()
        {

        }
    }
}
