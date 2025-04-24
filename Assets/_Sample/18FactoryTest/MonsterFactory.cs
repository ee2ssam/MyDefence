using UnityEngine;

namespace Sample
{
    //심플 팩토리
    //몬스터를 생성하는 클래스
    public class MonsterFactory
    {
        //몬스터 타입을 매개변수로 받아 타입에 맞게 몬스터를 생성하고 반환하는 함수
        public Monster CreateMonster(MonsterType monsterType)
        {
            switch(monsterType)
            {
                case MonsterType.M_Slime:
                    return new Slime();                    

                case MonsterType.M_Zombie:
                    return new Zombie();

                case MonsterType.M_Goblin:
                    return new Goblin();
            }

            //타입에 없으면 null 반환
            return null;
        }
    }
}