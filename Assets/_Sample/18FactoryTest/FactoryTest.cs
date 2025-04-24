using UnityEngine;

namespace Sample
{
    public class FactoryTest : MonoBehaviour
    {
        private void Start()
        {
            //심플 팩토리 객체 생성
            /*MonsterFactory monsterFactory = new MonsterFactory();

            //슬라임 생성
            Monster slime = monsterFactory.CreateMonster(MonsterType.M_Slime);
            slime.Attack();

            Monster zombie = monsterFactory.CreateMonster(MonsterType.M_Zombie);
            zombie.Attack();

            Monster slime2 = monsterFactory.CreateMonster(MonsterType.M_Goblin);
            slime2.Attack();*/

            //팩토리 메서드 패턴
            //슬라임 전용 공장
            SlimFactory slimFactory = new SlimFactory();
            Monster slime = slimFactory.CreatMonster(); //슬라임 생산
            slimFactory.SlimeCount();                   //생산한 슬라임 카운트
            Debug.Log($"slime: {slimFactory.count}");
            slime.Attack();

            //좀비 전용 공장
            ZombieFactory zombieFactory = new ZombieFactory();
            Monster zombie = zombieFactory.CreatMonster();      //좀비생산
            zombieFactory.AddSomething();
            zombie.Attack();

            //스켈레톤 전용 공장
            //...

        }
    }
}