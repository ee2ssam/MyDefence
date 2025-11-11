using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 사각형 모양의 영역에서 이펙트 플레이
    /// </summary>
    public class RectangleEffect : AreaOfEffect
    {
        public float width;
        public float height;

        public override float CalculateArea()
        {
            return width * height;
        }
    }
}
