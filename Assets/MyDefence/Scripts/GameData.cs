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

        private static int lives;                       //생명 갯수
        [SerializeField] private int startLives = 10;   //초기 생명 갯수

        private static int waves;       //Wave 카운트
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Gold
        {
            get {  return gold; }
        }

        //라이프 읽기 전용 속성
        public static int Lives => lives;

        //웨이브 카운트
        public static int Waves
        {
            get { return waves; }
            set { waves = value; }
        }
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            gold = startGold;       //초기 소지금을 지급
            lives = startLives;     //초기 생명 갯수
            waves = 0;              //웨이브 카운트
            //Debug.Log($"초기 소지금 {startGold}Gold를 지급하였습니다");
        }
        #endregion

        #region Custom Method
        //돈 벌기
        public static void AddGold(int amount)
        {
            gold += amount;
            //Debug.Log($"현재 소지금: {gold}");
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

        //생명 추가하기
        //ToDo : Max Lives 체크
        public static void AddLife(int amount)
        {
            lives += amount;
        }

        //생명 사용하기
        public static void UseLife(int amount = 1)
        {
            lives -= amount;
            //Debug.Log($"현재 라이프: {lives}");

            if (lives <= 0)
            {
                lives = 0;
            }
        }
        #endregion


    }
}