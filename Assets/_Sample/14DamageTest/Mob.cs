using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 데미지 주기 예제 클래스
    /// </summary>
    public class Mob : MonoBehaviour, IDamageable
    {
        #region Variables
        [SerializeField]                    //인스펙터창에서 표시하여 디버깅 하기 위해
        private float health;               //체력, 현재 체력
        [SerializeField]                    //인스펙터창에서 편집 가능하게 하기 위해
        private float startHealth = 150f;   //체력 초기값, MAX 체력
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            health = startHealth;
        }
        #endregion

        #region Custom Method
        //데미지 주기
        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log($"현재체력: {health}");

            //죽음 체크
            if (health <= 0f)
            {
                //킬
                Destroy(gameObject);
            }
        }
        #endregion
    }
}