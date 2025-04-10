using UnityEngine;

namespace MyDefence
{
    //탄환(발사체)를 관리하는 클래스 - 모든 발사체의 부모 클래스
    public class Bullet : MonoBehaviour
    {
        #region Field
        //타겟 오브젝트
        private Transform target;
        //이동 속도
        public float moveSpeed = 70f;

        //타격 이펙트 프리팹
        public GameObject bulletImpactPrefab;

        //공격 데미지
        [SerializeField] protected float attackDamage = 50f;
        #endregion

        public void SetTarget(Transform _target)
        {
            this.target = _target;
        }

        // Update is called once per frame
        void Update()
        {
            if(target == null)
            {
                Destroy(this.gameObject);
                return;
            }

            //이동하기
            //dir.magnitude : 두 벡터간의 거리
            Vector3 dir = target.position - this.transform.position; 
            float ditanceThisFrame = Time.deltaTime * moveSpeed;    //이번 프레임에 이동하는 거리
            if(dir.magnitude <= ditanceThisFrame)
            {
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //타겟을 바라보며 이동하기
            transform.LookAt(target);
        }

        //타겟을 맞추어 적을 킬 - 뷸렛
        protected virtual void HitTarget()
        {
            //타격 이펙트 효과
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //타겟에게 데미지 주기
            Damage(target);

            //탄환 게임오브젝트 킬
            Destroy(this.gameObject);
        }

        //매개변수로 들어온 타겟에게 데미지 주기
        protected void Damage(Transform _target)
        {
            //타겟 게임오브젝트 킬 - 원샷/원킬
            //Destroy(_target.gameObject);

            //attackDamage만큼 타겟의 Health 연산
            Enemy enemy = _target.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }
}