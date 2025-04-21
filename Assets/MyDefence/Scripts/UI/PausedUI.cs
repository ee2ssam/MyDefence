using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    //PausedUI 관리하는 클래스
    public class PausedUI : MonoBehaviour
    {
        #region Field
        //씬페이더
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";
        
        //UI 오브젝트
        public GameObject puasedUI;
        #endregion


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            puasedUI.SetActive(!puasedUI.activeSelf);

            //창이 열리면
            if (puasedUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else //창이 닫치면
            {
                Time.timeScale = 1f;
            }
        }

        public void Retry()
        {
            Time.timeScale = 1f;

            //해당(자기 자신) 씬을 다시 부른다
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
            fader.FadeTo(SceneManager.GetActiveScene().name); //씬이름으로 로드
        }

        public void Menu()
        {
            Time.timeScale = 1f;

            fader.FadeTo(loadToScene);
        }
    }
}