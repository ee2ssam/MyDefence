using UnityEngine;

namespace MyDefence
{
    //게임의 전체 진행을 관리하는 클래스
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크
        private static bool isGameOver = false;
        public static bool IsGameOver => isGameOver;

        //게임오버 UI
        public GameObject gameoverUI;

        //레벨 클리어시 unlock되는 레벨
        [SerializeField] private string keyName = "NowLevel";
        [SerializeField] private int unlockLevel = 2;
        //레벨 클리어 UI
        public GameObject levelClearUI;

        //치팅 체크
        private bool isCheating = false;
        #endregion

        private void Start()
        {
            //초기화
            isGameOver = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (isGameOver)
                return;

            //.....

            //게임 오버 체크
            if(PlayerStats.Lives <= 0)
            {
                GameOver();
            }

            //치팅
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
            if (Input.GetKeyDown(KeyCode.O) && isCheating)
            {
                //GameOver();
                LevelClear();
            }
        }

        public void LevelClear()
        {
            //LevelClear 관련 데이터 처리 : 보상, 저장
            //다음에 플레이 가능한 레벨
            int nowLevel = PlayerPrefs.GetInt(keyName, 1);
            //Debug.Log($"가져온 nowLevel: {nowLevel}");
            if(unlockLevel > nowLevel)
            {
                PlayerPrefs.SetInt(keyName, unlockLevel);
                //Debug.Log($"저장된 nowLevel: {unlockLevel}");
            }

            //UI창 활성화
            levelClearUI.SetActive(true);
        }

        void GameOver()
        {
            isGameOver = true;
            //UI창 활성화
            gameoverUI.SetActive(true);

            //벌..
        }

        //머니 치팅 - 10만 골드 지급
        void ShowMeTheMoney()
        {
            if (isCheating == false)
                return;

            PlayerStats.AddMoney(100000);
        }

        //레벨업 치팅 - 100
        void Levelup100()
        {
            if (isCheating == false)
                return;

            //level += 100;
        }

        //....

    }
}