using UnityEngine;

namespace MyDefence
{
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
            if(target == null)
            {
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
        }
        #endregion

        #region Custom Method
        //매개변수로 들어온 타겟으로 저장
        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        //타겟 명중
        private void HitTarget()
        {
            //타격위치에 이펙트를 생성(Instiate)한 후 3초뒤에 타격 이펙트 오브젝트 kill
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //타겟 킬
            Destroy(target.gameObject);
            //탄환 킬
            Destroy(this.gameObject);
        }
        #endregion
    }
}