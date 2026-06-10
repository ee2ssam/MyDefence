using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임의 전체 흐름을 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //치트키
            if(Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
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