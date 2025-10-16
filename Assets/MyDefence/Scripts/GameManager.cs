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
        }
        #endregion

        #region Custom Method
        //게임오버 처리
        private void GameOver()
        {
            Debug.Log("Game Over");

            isGameOver = true;

        }
        #endregion
    }
}