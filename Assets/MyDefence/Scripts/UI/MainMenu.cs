using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";
        #endregion

        public void Play()
        {
            //Debug.Log("Goto Play Scene");
            fader.FadeTo(loadToScene);
        }

        public void Quit()
        {
            //Cheating
            PlayerPrefs.DeleteAll();

            Debug.Log("Game Quit");
            Application.Quit();
        }
    }
}
