using UnityEngine;

namespace MyDefence
{
    public class LevelClearUI : MonoBehaviour
    {
        #region Field
        //씬 전환
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        [SerializeField] private string loadToNext = "LevelSelect";
        #endregion

        //컨티뉴 버튼 클릭시 호출 - 레벨셀렉트 씬으로 이동
        public void Continue()
        {
            fader.FadeTo(loadToNext);
        }

        //메뉴 버튼 클릭시 호출 - 메인메뉴 씬으로 이동
        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}
