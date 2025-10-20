using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 데미지를 입는 오브젝트 정의
    /// </summary>
    public interface IDamageable
    {
        public void TakeDamage(float damage);
    }
}