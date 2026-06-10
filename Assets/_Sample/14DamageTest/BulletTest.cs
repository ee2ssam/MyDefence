using MyDefence;
using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 데미지 테스트 예제용 탄환 클래스
    /// </summary>
    public class BulletTest : Bullet
    {
        #region Variables
        [SerializeField]
        private float attackDamage = 50f;   //공격력
        #endregion

        #region Custom Method
        protected override void Damage(Transform _targert)
        {
            //타격 당한 오브젝트에게 데미지 주기
            Debug.Log($"{_targert.ToString()}에게 {attackDamage}만큼 데미지 주기");

            //원샷 원킬
            //Destroy(_targert.gameObject);

            //데미지 입는 기능이 있는지 체크
            //IDamageable의 인스턴스 가져오기
            IDamageable damageable = _targert.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }

            //몬스터에게 {attackDamage}만큼 데미지 주기
            /*//Monster의 인스턴스 가져오기
            Monster monster = _targert.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(attackDamage);
            }*/

            /*//Mob의 인스턴스 가져오기
            Mob mob = _targert.GetComponent<Mob>();
            if(mob != null)
            {
                mob.TakeDamage(attackDamage);
            }*/

        }
        #endregion
    }
}