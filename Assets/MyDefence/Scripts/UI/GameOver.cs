using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 게임오버 UI를 관리하는 클래스
    /// </summary>
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        //Rounds 텍스트
        public TextMeshProUGUI roundsText;
        #endregion

        #region Unity Event Method
        //게임오버 UI가 활성화 될때 PlayerStats.Rounds 값을 한번만 가져온다
        private void OnEnable()
        {
            //Rounds 텍스트에 PlayerStats Rounds값 적용
            roundsText.text = PlayerStats.Rounds.ToString() + " ROUNDS SURVIVED";
        }
        #endregion


        #region Custom Method
        //메인메뉴 버튼을 눌렀을때 호출
        public void MainMenu()
        {
            //Debug.Log("Goto MainMenu!!!");
            fader.FadeTo(loadToScene);
        }

        //게임 재시작 버튼 눌렀을때 호출
        public void Restart()
        {
            Debug.Log("Run RePaly!!!");

            //현재 플레이하고 있는 씬을 다시 호출
            //int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;
            string nowSceneName = SceneManager.GetActiveScene().name;
            fader.FadeTo(nowSceneName);
        }
        #endregion
    }
}
