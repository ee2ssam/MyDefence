using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임 데이터 변수를 관리하는 클래스
    /// 게임머니
    /// </summary>
    public class GameData : MonoBehaviour
    {
        #region Variables
        private static int gold;       //소지금
        public int startGold = 400;    //초기 소지금
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Gold
        {
            get {  return gold; }
        }
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            gold = startGold;       //초기 소지금을 지급
            Debug.Log($"초기 소지금 {startGold}Gold를 지급하였습니다");
        }
        #endregion

        #region Custom Method
        //돈 벌기
        public static void AddGold(int amount)
        {
            gold += amount;
        }

        //돈 쓰기, 결재 여부를 bool 반환
        public static bool UseGold(int amount)
        {
            //돈 부족 체크
            if(gold < amount)
            {
                //Debug.Log("소지금이 부족합니다");
                return false;
            }

            gold -= amount;
            return true;
        }

        //소지금 체크, 결재 가능 여부 bool 반환
        public static bool HasGold(int amount)
        {
            return gold >= amount;
        }
        #endregion


    }
}