using UnityEngine;

namespace Sample
{
    //몬스터의 타입 정의
    public enum MonsterType
    {
        M_Slime,
        M_Zombie,
        M_Goblin
        //......
    }

    //모든 몬스터의 부모 추상 클래스
    public abstract class Monster
    {
        //몬스터 속성, 몬스터 기능 정의, 구현

        public abstract void Attack();
    }

    //슬라임을 관리하는 클래스
    public class Slime : Monster
    {
        public override void Attack()
        {
            Debug.Log("Slime Attack!!!");
        }
    }

    //좀비를 관리하는 클래스
    public class Zombie : Monster
    {
        public override void Attack()
        {
            Debug.Log("Zombie Attack!!!");
        }
    }

    //고블린을 관리하는 클래스
    public class Goblin : Monster
    {
        public override void Attack()
        {
            Debug.Log("Goblin Attack!!!");
        }
    }

    //.....
}
