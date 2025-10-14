using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 탄환 발사체를 관리하는 클래스
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        #region Variables
        //타겟 오브젝트
        private Transform target;

        //이동 속도
        public float moveSpeed = 70f;

        //타격 이펙트 프리팹 오브젝트
        public GameObject impactPrefab;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //타겟이 킬 되면
            if(target == null)
            {
                Destroy(gameObject);
                return;
            }

            //타겟까지 이동하기
            Vector3 dir = target.position - transform.position;
            //남은 거리 (dir.magnitude 와 동일하다)
            float distance = Vector3.Distance(target.position, transform.position);
            //이번 프레임에 이동한 거리
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if(dir.magnitude <= distanceThisFrame)
            {                
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //타겟 방향으로 바라보기
            transform.LookAt(target);
        }
        #endregion

        #region Custom Method
        //매개변수로 들어온 타겟으로 저장
        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        //타겟 명중
        protected virtual void HitTarget()
        {
            //타격위치에 이펙트를 생성(Instiate)한 후 3초뒤에 타격 이펙트 오브젝트 kill
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //타격당한 적에게 데미지 주기
            Damage(target);

            //탄환 킬
            Destroy(this.gameObject);
        }

        //타격당한 적에게 데미지 주기
        protected void Damage(Transform enemy)
        {
            //타겟 킬
            Destroy(enemy.gameObject);
        }
        #endregion
    }
}