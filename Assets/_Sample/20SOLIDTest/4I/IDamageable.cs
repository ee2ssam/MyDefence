using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 캐릭터 데미지 기능 정의
    /// </summary>
    public interface IDamageable
    {
        public void TakeDamage(float damage);
    }
}