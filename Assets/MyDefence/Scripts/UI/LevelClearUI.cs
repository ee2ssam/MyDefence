using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 레벨클리어 UI 관리하는 클래스
    /// </summary>
    public class LevelClearUI : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField]
        private string loadToScene = "MainMenu";
        [SerializeField]
        private string nextScene = "Level02";
        #endregion

        #region Custom Method
        //NextLevel 버튼 클릭시 호출
        public void NextLevel()
        {
            fader.FadeTo(nextScene);
        }

        //메인메뉴 버튼 클릭시 호출
        public void MainMenu()
        {
            fader.FadeTo(loadToScene);
        }
        #endregion
    }
}