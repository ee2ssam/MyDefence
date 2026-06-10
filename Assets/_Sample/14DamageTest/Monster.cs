using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 데미지 주기 예제 클래스, 모든 몬스터들의 부모 클래스
    /// </summary>
    public class Monster : MonoBehaviour, IDamageable
    {
        #region Variables
        [SerializeField]                    //인스펙터창에서 표시하여 디버깅 하기 위해
        protected float health;               //체력, 현재 체력
        [SerializeField]                    //인스펙터창에서 편집 가능하게 하기 위해
        protected float startHealth = 100f;   //체력 초기값, MAX 체력
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
            if(health <= 0f)
            {
                //킬
                Destroy(gameObject);
            }
        }
        #endregion
    }
}