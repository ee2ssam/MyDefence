using UnityEngine;

namespace MyDefence
{
    //메인메뉴 씬을 관리하는 클래스
    public class MainMenu : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion

        //플레이버튼 클릭하면 호출되는 함수
        public void Play()
        {
            fader.FadeTo(loadToScene);
        }

        //게임 종료버튼 클리하면 호출되는 함수(어플리케이션 종료)
        public void Quit()
        {
            //Cheating
            PlayerPrefs.DeleteAll();

            Debug.Log("Quit Game!!!");
            //Unity 에디터에서 명령 무시, 빌드버전에서는 구동
            Application.Quit();
        }
    }
}