using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 메인메뉴를 관리하는 클래스
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        //씬페이더 인스턴스
        public SceneFader fader;

        //다음 씬 이름
        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //페이더 시작
            fader.FadeStart();
        }
        #endregion

        #region Custom Method
        //플레이 버튼 클릭시 호출
        public void Play()
        {
            //Debug.Log($"goto {loadToScene}");
            fader.FadeTo(loadToScene);
        }

        //게임 종료 버튼 클릭시 호출
        public void Quit()
        {
            //To Do : 치트키
            //PlayerPrefs.DeleteAll();

            Debug.Log("Game Quit");
            //어플 종료 명령 (에디터에서는 명령 무시, 실행파일에서는 명령 시행)
            Application.Quit();
        }
        #endregion
    }
}