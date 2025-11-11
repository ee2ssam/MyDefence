using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 원 모양의 영역에서 이펙트 플레이
    /// </summary>
    public class CircleEffect : AreaOfEffect
    {
        [SerializeField]
        private float radius = 10f;

        public override float CalculateArea()
        {
            return radius * radius * Mathf.PI;
        }
    }
}