using UnityEditor.PackageManager;
using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임의 전체를 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크 변수
        private static bool isGameOver = false;

        //레벨 클리어 체크 변수
        private static bool isLevelClear = false;

        //게임오버 UI
        public GameObject gameOverUI;
        //레벨클리어 UI
        public GameObject levelClearUI;

        //현재 플레이씬의 레벨
        [SerializeField]
        private int nowLevel = 1;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Property
        public static bool IsGameOver
        {
            get { return isGameOver; }
            private set { isGameOver = value; }
        }
        public static bool IsLevelClear
        {
            get { return isLevelClear; }
            set { isLevelClear = value; }
        }
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            IsGameOver = false;
            IsLevelClear = false;
        }

        private void Update()
        {
            if (IsGameOver)
                return;

            //게임 종료 체크
            if(PlayerStats.Lives <= 0)
            {
                GameOver();
            }

            //레벨 클리어 체크
            if (IsLevelClear)
            {
                LevelClear();
            }

            //치트키
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
            if(Input.GetKeyDown(KeyCode.O))
            {
                ShowMeGameOverUI();
            }
        }
        #endregion

        #region Custom Method
        //게임오버 처리
        private void GameOver()
        {
            //Debug.Log("Game Over");
            IsGameOver = true;

            //효과: vfx, sfx
            //패널티 적용

            //UI 창 열기
            gameOverUI.SetActive(true);
        }

        //레벨 클리어 처리
        public void LevelClear()
        {
            //Debug.Log("Level Clear");
            IsGameOver = true;

            //게임 데이터 저장
            int saveLevel = PlayerPrefs.GetInt("ClearLevel", 0);
            if (saveLevel < nowLevel)
            {
                PlayerPrefs.SetInt("ClearLevel", nowLevel);
                //Debug.Log($"Save clearLevel: {nowLevel}");
            }

            //UI 창 열기
            levelClearUI.SetActive(true);
        }

        //치트키
        void ShowMeTheMoney()
        {
            //치트 체크
            if (isCheating == false)
                return;

            //10만 골드 지급
            PlayerStats.AddMoney(100000);
        }

        void ShowMeGameOverUI()
        {
            //치트 체크
            if (isCheating == false)
                return;

            GameOver();
        }

        void LevelupCheat()
        {
            //치크 체크
            if (isCheating == false)
                return;

            //level++;
        }

        //...
        #endregion
    }
}