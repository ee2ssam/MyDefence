using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 전투 가능한 유닛: 체력, 데미지 입는 기능을 가지고 있다
    /// </summary>
    public class Target : Health, IDamageable
    {
        public void TakeDamage(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}