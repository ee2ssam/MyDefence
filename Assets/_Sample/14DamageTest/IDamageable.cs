using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 데미지 입는 기능 구현을 강제하는 인터페이스
    /// 데미지 입기
    /// </summary>
    public interface IDamageable
    {
        public void TakeDamage(float damage);
    }
}