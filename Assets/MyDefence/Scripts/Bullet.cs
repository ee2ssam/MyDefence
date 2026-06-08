using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 탄환을 관리하는 클래스, 모든 발사체에 들어가는 부모 클래스
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        #region Variables
        private Transform target;    //이동 목표 오브젝트의 트랜스폼 인스턴스
        public float moveSpeed = 50f;     //탄환 이동 속도

        //타격 효과
        public GameObject bulletImpactPrefab;   //임팩트 파티클 게임오브젝트 인스턴스
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //타겟 검증
            if(target == null)
            {
                Destroy(this.gameObject);
                return;
            }

            //타겟을 향해 이동 : dir, Time.deltaTime, speed
            Vector3 dir = target.position - transform.position;
            //충돌 체크 - 남은거리와 이번 프레임에 이동하는 거리 비교
            float distance = Vector3.Distance(this.transform.position, target.position);
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if (distance <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        }
        #endregion

        #region Custom Method
        //타겟 설정하기
        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        //타겟 충돌
        protected virtual void HitTarget()
        {
            //뷸렛이 적을 타격할때 뷸렛이 부서져서 파편이 날아가는 효과
            if(bulletImpactPrefab) //bulletImpactPrefab != null
            {
                GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
                //킬 예약
                Destroy(effectGo, 3f);
            }

            //Debug.Log("Hit Target!!!");
            //타겟에게 데미지 주기
            Damage(target);

            //탄환 게임오브젝트 kill (Destory)
            Destroy(this.gameObject);
        }

        //타격 당한 적에게 데미지 주기 - 킬
        protected void Damage(Transform enemy)
        {
            Destroy(enemy.gameObject);
        }
        #endregion
    }
}