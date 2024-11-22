using UnityEngine;

namespace MyDefence
{
    public class LevelClearUI : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField] private string nextScene = "Level02";
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        //다음 레벨씬으로 이동
        public void Continue()
        {
            fader.FadeTo(nextScene);
        }

        //메뉴 씬으로 이동
        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}
