using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 데미지 입는 기능 구현을 강제하는 추상 클래스
    /// </summary>
    public abstract class DamageableAbst : MonoBehaviour
    {
        public abstract void TakeDamage(float damage);
    }
}