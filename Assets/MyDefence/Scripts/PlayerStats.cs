using UnityEngine;

namespace MyDefence
{
    //플레이어의 속성(데이터)들을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Field
        //소지금
        private static int money;

        //초기 소지금
        [SerializeField] private int startMoney = 400;

        //Life
        private static int lives;

        //초기 생명력
        [SerializeField] private int startLives = 10;
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }

        //Life 읽기 전용 속성
        public static int Lives
        {
            get { return lives; }
        }

        //Round 카운트
        public static int Rounds { get; set; }
        #endregion

        private void Start()
        {
            //초기화
            //초기 소지금 지급 400, 초기 생명 10 지급
            money = startMoney;
            lives = startLives;
            Rounds = 0;
        }

        //벌기, 쓰기, 소지금 확인 함수 만들기
        public static void AddMoney(int amount)
        {
            money += amount;
        }

        public static bool UseMoney(int amount)
        {
            //소지금 체크
            if(money < amount)
            {
                Debug.Log("소지금이 부족합니다");
                return false;
            }

            money -= amount;
            return true;
        }

        public static bool HasMoney(int amount)
        {
            return money >= amount;
        }

        //생명 추가
        public static void AddLife(int amount)
        {
            lives += amount;
        }

        //생명 사용하기, 소모
        public static void UseLife(int amount)
        {
            lives -= amount;

            if(lives <= 0)
            {
                lives = 0;
            }
        }


    }
}
