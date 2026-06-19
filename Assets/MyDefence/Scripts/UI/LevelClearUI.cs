using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 레벨 클리어 UI를 관리하는 클래스
    /// </summary>
    public class LevelClearUI : MonoBehaviour
    {
        #region Variables
        //씬페이더 인스턴스
        public SceneFader fader;

        //다음 씬 이름
        [SerializeField]
        private string nextLevel = "Level02";

        //메인메뉴 씬 이름
        [SerializeField]
        private string loadToScene = "MainMenu";
        #endregion

        #region Custom Method
        //메인메뉴 버튼 클릭시 호출
        public void MainMenu()
        {
            fader.FadeTo(loadToScene);
        }

        //다음레벨 버튼 클릭시 호출
        public void NextLevel()
        {
            fader.FadeTo(nextLevel);
        }
        #endregion
    }
}