using UnityEngine;

namespace Sample
{
    public class MonsterFactory
    {
        //매개변수로 MonsterType을 받아서 타입에 맞게 몬스터를 생성하고 Monster를 반환하는 함수
        public Monster CreateMonster(MonsterType mType)
        {
            switch (mType)
            {
                case MonsterType.M_Slime:
                    return new Slime();
                case MonsterType.M_Zombie:
                    return new Zombie();
                case MonsterType.M_Goblin:
                    return new Goblin();
            }

            return null;
        }
    }
}