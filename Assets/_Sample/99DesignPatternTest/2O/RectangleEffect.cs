using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid
{
    public class RectangleEffect : AreaOfEffect
    {
        public float m_Width;
        public float m_Height;

        public override float CaculateArea()
        {
            return m_Width * m_Height;
        }
    }
}