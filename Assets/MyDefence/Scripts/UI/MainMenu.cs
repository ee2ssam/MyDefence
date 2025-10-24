using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion

        #region Custom Method
        //플레이버튼 클릭시 호출
        public void Play()
        {
            //Debug.Log("Goto Play Scene");
            SceneManager.LoadScene(loadToScene);
        }

        //게임나가기 버튼 클릭시 호출
        public void Quit()
        {
            Debug.Log("Game Quit");
            Application.Quit();         //에디터에서는 명령 무시, 실행 파일에서는 명령 실행
        }
        #endregion
    }
}
