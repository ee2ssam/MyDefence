using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public class CircleEffect : AreaOfEffect
    {
        public float m_Radius;

        public override float CaculateArea()
        {
            return m_Radius * m_Radius * Mathf.PI;
        }
    }
}
