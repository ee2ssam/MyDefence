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
        private bool isGameOver = false;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            if (isGameOver)
                return;

            //게임 종료 체크
            if(PlayerStats.Lives <= 0)
            {
                GameOver();
            }

            //치트키
            if(Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
        }
        #endregion

        #region Custom Method
        //게임오버 처리
        private void GameOver()
        {
            Debug.Log("Game Over");

            isGameOver = true;

        }

        //치트키
        void ShowMeTheMoney()
        {
            //치크 체크
            if (isCheating == false)
                return;

            //10만 골드 지급
            PlayerStats.AddMoney(100000);
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