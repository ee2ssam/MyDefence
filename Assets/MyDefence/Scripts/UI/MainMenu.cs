using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 메인메뉴 씬을 관리하는 클래스
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion

        #region Custom Method
        //플레이버튼 클릭시 호출
        public void Play()
        {
            //Debug.Log("Goto Play Scene");
            fader.FadeTo(loadToScene);
        }

        //게임나가기 버튼 클릭시 호출
        public void Quit()
        {
            //Cheating
            //저장된 데이터 삭제
            PlayerPrefs.DeleteAll();

            Debug.Log("Game Quit");
            Application.Quit();         //에디터에서는 명령 무시, 실행 파일에서는 명령 실행
        }
        #endregion
    }
}
