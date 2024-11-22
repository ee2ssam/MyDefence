using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";

        public GameObject pauseUI;
        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if(pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }        

        public void Retry()
        {
            Time.timeScale = 1f;
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            Time.timeScale = 1f;
            fader.FadeTo(loadToScene);
        }

    }
}