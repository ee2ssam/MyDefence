using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 데미지를 입는 오브젝트 정의
    /// </summary>
    public interface IDamageable
    {
        public void TakeDamage(float damage);   //데미지 주기
        public void Slow(float rate);           //이동속도 느리게 하기
    }
}