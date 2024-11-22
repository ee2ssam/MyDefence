using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    public class Missile : Bullet
    {
        #region Variables
        public float damageRange = 3.5f;

        //적 태그
        public string enemyTag = "Enemy";
        #endregion

        protected override void HitTarget()
        {
            //Hit 효과
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //반경 damageRange(3.5)안에 있는 모든 enemy들 데미지 입고 kill
            Explosion();

            //탄환 게임오브젝트 kill (Destroy)
            Destroy(this.gameObject);
        }

        //반경 damageRange(3.5)안에 있는 모든 enemy들 데미지 입고 kill
        void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
            foreach (var collider in hitColliders)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    Damage(collider.transform);
                }
            }
        }

        //damageRange 기즈모 그리기
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }
    }
}