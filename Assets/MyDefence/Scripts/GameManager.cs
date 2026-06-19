using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임의 전체 흐름을 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //현재 레벨
        [SerializeField] private int nowLevel;

        //레벨 클리어 체크
        public static bool isClearLevel = false;

        //게임오버 체크
        private bool isGameOver = false;

        //게임오버 UI 게임오브젝트 인스턴스
        public GameObject gameOverUI;

        //레벨클리어 UI 게임오브젝트 인스턴스
        public GameObject levelClearUI;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            isGameOver = false;
            isClearLevel = false;
        }

        private void Update()
        {
            //게임오버 / 레벨 클리어시 더이상 진행하지 않도록 막는다
            if (isGameOver)
                return;

            //게임 오버 체크
            if(GameData.Lives <= 0)
            {
                GameOver();
            }

            //레벨 클리어 체크
            if(isClearLevel)
            {
                LevelClear();
            }

            //치트키
            if(Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
            if (Input.GetKeyDown(KeyCode.O) && isCheating)
            {
                GameOver();
            }
        }
        #endregion

        #region Custom Method
        //게임오버 처리
        void GameOver()
        {
            Debug.Log("Game Over!!!!");
            isGameOver = true;

            //벌
            //게임오버 UI 보여주기(활성화)
            gameOverUI.SetActive(true);
        }

        //레벨 클리어 처리
        void LevelClear()
        {
            Debug.Log("Level Clear!!!!");
            isGameOver = true;

            //게임 데이터 저장 - 
            int clearLevel = PlayerPrefs.GetInt("ClearLevel", 0);
            //저장된 데이터 체크
            if (nowLevel > clearLevel)
            {
                PlayerPrefs.SetInt("ClearLevel", nowLevel);
                Debug.Log($"Save Clear Level: {nowLevel}");
            }

            //상
            //UI 보여주기(활성화)
            levelClearUI.SetActive(true);
        }
        #endregion

        #region Cheating
        //골드 치팅
        void ShowMeTheMoney()
        {
            //치팅 체크
            if (isCheating == false)
                return;

            //10만골드 지급
            GameData.AddGold(100000);
        }

        //레벨 치팅
        void LevelupCheat()
        {
            //치팅 체크
            if (isCheating == false)
                return;

            //level++;
        }
        #endregion
    }
}