using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 데미지 주기 예제 클래스
    /// </summary>
    public class CubeTest : MonoBehaviour, IDamageable
    {
        public void TakeDamage(float damage)
        {
            Destroy(gameObject);
        }
    }
}