using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임의 전체 흐름을 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크
        private bool isGameOver = false;

        //게임오버 UI 게임오브젝트 인스턴스
        public GameObject gameOverUI;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            isGameOver = false;
        }

        private void Update()
        {
            //게임오버시 더이상 진행하지 않도록 막는다
            if (isGameOver)
                return;

            //게임 오버 체크
            if(GameData.Lives <= 0)
            {
                GameOver();
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