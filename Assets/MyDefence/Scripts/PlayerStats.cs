using Mono.Cecil.Cil;
using UnityEngine;

namespace MyDefence
{
    //플레이어의 속성들을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Field
        //소지금
        private static int money;

        //초기 소지금
        [SerializeField] private int startMoney = 400;
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }
        #endregion
                
        private void Start()
        {
            //초기화
            //초기 소지금 지급 400
            money = startMoney;
            Debug.Log("초기 소지금 400 Gold 지급");
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

    }
}
