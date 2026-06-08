using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 로켓 Propjectile 을 관리하는 bullet을 상속받는 클래스
    /// </summary>
    public class Rocket : Bullet
    {
        #region Variables
        //폭발 범위 - 일정범위 안에 있는 적들에게 데미지 주기
        public float damageRange = 3.5f;
        #endregion

        #region Unity Event Method
        //해당(this, 스크립트가 붙어있는) 오브젝트를 선택했을때만 기즈모를 그린다
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            //타워를 중심으로 반경이 3.5인 구를 그린다
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }
        #endregion

        #region Custom Method
        //타겟 충돌
        protected override void HitTarget()
        {
            //뷸렛이 적을 타격할때 뷸렛이 부서져서 파편이 날아가는 효과
            if (bulletImpactPrefab) //bulletImpactPrefab != null
            {
                GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
                //킬 예약
                Destroy(effectGo, 3f);
            }

            //Debug.Log("Hit Target!!!");
            //타겟위치에서 폭발
            Explosion();

            //탄환 게임오브젝트 kill (Destory)
            Destroy(this.gameObject);
        }

        //타겟 위치에서 일정범위 안에 있는 적들에게 데미지 주기
        private void Explosion()
        {
            //데미지 범위 안에 있는 모든 충돌체 가져오기
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);

            //Debug.Log($"hitColliders: {hitColliders.Length}");
            //모든 충돌체에서 enemy들만 (tag) 찾아서 데미지 주기
            foreach (Collider collider in hitColliders)
            {
                //태그 검사
                if(collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }
        #endregion
    }
}