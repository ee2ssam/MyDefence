using UnityEngine;

namespace MyDefence
{
    //플레이어의 속성을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //소지금
        private static int money;
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }
        //게임 시작시 지급하는 초기 소지금
        [SerializeField] private int startMoney = 400;

        //라이프
        private static int lives;
        //라이프 읽기 전용 속성
        public static int Lives => lives;
        //게임 시작시 지급하는 초기 생명값
        [SerializeField] private int startLives = 10;

        //라운드
        private static int rounds;
        public static int Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }
        #endregion

        private void Start()
        {
            //초기화
            money = startMoney;
            lives = startLives;
            rounds = 0;
        }

        //돈을 번다
        public static void AddMoney(int amount)
        {
            money += amount;
        }

        //돈을 쓴다
        public static bool UseMoney(int amount)
        {
            //소지금 체크
            if (!HasMoney(amount))
            {
                Debug.Log("소지금이 부족합니다");
                return false;
            }

            money -= amount;
            return true;
        }

        //소지금 잔금 확인
        public static bool HasMoney(int amount)
        {
            return money >= amount;
        }

        //라이프 추가
        public static void AddLives(int amount)
        {
            lives += amount;
        }

        //라이프 사용
        public static void UseLives(int amount)
        {
            lives -= amount;

            if (lives <= 0)
            {
                lives = 0;
            }
        }

    }
}
