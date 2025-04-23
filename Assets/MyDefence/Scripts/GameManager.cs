using UnityEngine;

namespace MyDefence
{
    //게임의 전체 흐름을 관리하는 클래스
    public class GameManager : MonoBehaviour
    {
        #region Field
        //치트 체크
        [SerializeField] private bool isCheat = false;

        //게임오버
        //UI
        public GameObject gameOverUI;
        private static bool isGameOver = false;

        //레벨 클리어
        [SerializeField]
        private int unLockLevel = 2;
        #endregion

        #region Propeyty
        public static bool IsGameOver
        {
            get { return isGameOver; }
        }
        #endregion

        private void Start()
        {
            //초기화
            isGameOver = false;

        }

        private void Update()
        {
            if (IsGameOver)
                return;

            //게임오버 되었는지 체크
            if (PlayerStats.Lives <= 0)
            {
                ShowGameOverUI();
            }

            //Cheating
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
            if(Input.GetKeyDown(KeyCode.O) && isCheat == true)
            {
                ShowGameOverUI();
            }
        }

        //게임오버 UI 보여주기
        void ShowGameOverUI()
        {
            isGameOver = true;
            gameOverUI.SetActive(true);
        }

        //레벨 클리어 처리
        public void LevelClear()
        {
            //데이터 처리 - 보상, 다음 언락 레벨 저장
            //저장되어 있는 데이터 가져오기
            int nowLevel = PlayerPrefs.GetInt("NowLevel", 1);
            if(unLockLevel > nowLevel)
            {
                PlayerPrefs.SetInt("NowLevel", unLockLevel);
            }
            //...

            //UI 보여주기, VFX, SFX 효과
            Debug.Log("레벨 클리어");
        }


        //Cheating
        //M키를 누르면 10만 골드 지급
        void ShowMeTheMoney()
        {
            if (isCheat == false)
                return;

            PlayerStats.AddMoney(1000000);
        }

        //레벨업 치팅
        void LevelUpCheat()
        {
            if (isCheat == false)
                return;

            //PlayerStats.LevelUp();
        }

        //...
    }
}