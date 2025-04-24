using UnityEngine;

namespace Sample
{
    //몬스터의 타입 정의
    public enum MonsterType
    {
        M_Slime,
        M_Zombie,
        M_Goblin,
        M_Skeleton
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

    //스켈레톤을 관리하는 클래스
    public class Skeleton : Monster
    {
        public override void Attack()
        {
            Debug.Log("Skeleton Attack!!!");
        }
    }

    //.....
}

/*
팩토리 패턴
1) 심플 팩토리

2) 팩토리 메서드 패턴
 - 심플 팩토리 확장
 - 팩토리에서 기능 추가

3) 추상 팩토리 패턴
 - 심플 팩토리 확장
 - 여러개의 객체가 생성



*/