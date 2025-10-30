using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// Paused UI를 관리하는 클래스
    /// Paused UI 활성화, 비활성, x, 메인메뉴, 다시하기 버튼 기능
    /// </summary>
    public class PausedUI : MonoBehaviour
    {
        #region Variables
        //Paused UI 게임 오브젝트
        public GameObject paused;

        //씬 페이더
        public SceneFader fader;
        //메뉴 씬 이름
        [SerializeField]
        private string loadToScene = "MainMenu";
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //게임오버 체크
            if (GameManager.IsGameOver)
                return;

            //ESC 키 입력시 Pause 활성화, 다시 ESC 키 입력시 비활성화
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }

        }
        #endregion

        #region Custom Method
        public void Toggle()
        {
            paused.SetActive(!paused.activeSelf);

            //창이 열렸냐?
            if (paused.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else //창이 닫혔냐?
            {
                Time.timeScale = 1f;
            }
        }

        public void MainMenu()
        {
            //Debug.Log("Goto MainMenu!!!");
            fader.FadeTo(loadToScene);
            Time.timeScale = 1f;
        }

        public void Restart()
        {
            //현재 플레이하고 있는 씬을 새로 로드하기
            int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.LoadScene(nowBuildIndex);
            fader.FadeTo(nowBuildIndex);

            Time.timeScale = 1f;
        }
        #endregion
    }
}