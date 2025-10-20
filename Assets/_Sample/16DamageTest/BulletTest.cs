using UnityEngine;
using MyDefence;

namespace Sample
{
    public class BulletTest : MonoBehaviour
    {
        #region Variables
        //타겟 오브젝트
        private Transform target;

        //이동 속도
        public float moveSpeed = 70f;

        //타격 이펙트 프리팹 오브젝트
        public GameObject impactPrefab;

        //공격 데미지
        [SerializeField]
        private float attackDamage = 50f;
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
        protected void Damage(Transform _target)
        {
            //타겟 킬
            //Destroy(_target.gameObject);

            // _target에게 attackDamage를 준다
            /*Enemy enemy = _target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }*/

            /*Zombie zombie = _target.GetComponent<Zombie>();
            if (zombie)
            {
                zombie.TakeDamage(attackDamage);
            }

            Slime slime = _target.GetComponent<Slime>();
            if (slime)
            {
                slime.TakeDamage(attackDamage);
            }*/

            //다형성: 부모 클래스의 이름으로 자식 클래스의 인스턴스를 읽어온다
            //Monster 클래스를 상속받은 몬스터 찾기
            Monster monster = _target.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(attackDamage);
            }

            //IDamageable 인터페이스를 상속받는 몬스터 찾기
            IDamageable damageable = _target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }


        }
        #endregion
    }
}