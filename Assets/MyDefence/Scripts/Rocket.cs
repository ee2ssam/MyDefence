using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 미사일 발사체를 관리하는 클래스, Bullet를 상속 받는다
    /// </summary>
    public class Rocket : Bullet
    {
        #region Variables
        //거리안에 있는 적에게 데미지 주는 범위
        public float damageRange = 3.5f;
        #endregion

        #region Unity Event Method
        //데미지 범위 표시하기
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, damageRange);
        }
        #endregion

        #region Custom Method
        protected override void HitTarget()
        {
            //타격위치에 이펙트를 생성(Instiate)한 후 3초뒤에 타격 이펙트 오브젝트 kill
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //damageRange안에 있는 모든 적에게 데미지 주는 범위
            Explosion();

            //탄환 킬
            Destroy(this.gameObject);
        }

        //damageRange안에 있는 모든 적(enemy)에게 데미지 주는 범위
        private void Explosion()
        {
            //데미지 범위안에 있는 모든 충돌체 가져오기
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);

            //모든 충돌체 중에서 enemy 찾아서 데미지 주기
            foreach (Collider collider in hitColliders)
            {
                //enemy 찾기 - tag 검사
                if(collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }

        }
        #endregion
    }
}
