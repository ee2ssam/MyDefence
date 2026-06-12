using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class PausedUI : MonoBehaviour
    {
        #region Variables
        //게임중 메뉴 UI 게임오브젝트 인스턴스
        public GameObject pausedUI;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //ESC 키 입력시      Pause 활성화 (게임 일단 멈춤 - 적들의 움직임, 카운트다운 멈춤)
            //다시 ESC 키 입력시 Pause 비활성화 (게임다시진행)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }
        #endregion

        #region Custom Method
        public void Toggle()
        {
            //비활성시
            pausedUI.SetActive(!pausedUI.activeSelf);

            //창이 열렸는냐?
            if(pausedUI.activeSelf)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }

        //메인메뉴 버튼 클릭시 호출
        public void MainMenu()
        {
            Time.timeScale = 1.0f;

            Debug.Log("Goto MainMenu!!!");
        }

        //리스타트 버튼 클릭시 호출
        public void ReStart()
        {
            Time.timeScale = 1.0f;

            //Debug.Log("ReStart!!!");
            //현재 플레이하고 있는 씬을 다시 로드한다
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        #endregion
    }
}