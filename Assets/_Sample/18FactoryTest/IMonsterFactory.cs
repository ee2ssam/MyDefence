using UnityEngine;

namespace Sample
{
    //팩토리 메서드 패턴
    //팩토리 메서드 - 생성하는 메서드를 추상화한다
    public interface IMonsterFactory
    {
        //몬스터를 반환하는 팩토리 메서드
        public Monster CreatMonster();
    }

    //슬라임을 생성하는 전용 팩토리
    public class SlimFactory : IMonsterFactory
    {
        public int count = 0;

        public Monster CreatMonster()
        {
            return new Slime();
        }

        //슬라임 생성 갯수 카운팅
        public void SlimeCount() => count++;

    }

    //좀비를 생성하는 전용 팩토리
    public class ZombieFactory : IMonsterFactory
    {
        public Monster CreatMonster()
        {
            return new Zombie();
        }

        public void AddSomething()
        {
            Debug.Log("다른 무언가 기능 추가");
        }
    }

    //고블린 팩토리....


    //스켈레톤 전용 공장
    public class SkeletonFactory : IMonsterFactory
    {
        public Monster CreatMonster()
        {
            return new Skeleton();
        }
    }
}