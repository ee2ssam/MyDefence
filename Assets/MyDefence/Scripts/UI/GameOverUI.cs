using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyDefence
{
    //GameOverUI 관리하는 클래스
    public class GameOverUI : MonoBehaviour
    {
        #region Field
        //씬페이더
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        public TextMeshProUGUI roundText;
        #endregion

        //활성화시 한번만 호출하고 값을 초기화한다
        private void OnEnable()
        {
            roundText.text = PlayerStats.Rounds.ToString();
        }

        //다시하기 버튼 클릭시 호출
        public void Retry()
        {
            //게임 초기화
            //GameManager.isGameOver = false;
            //...

            //해당(자기 자신) 씬을 다시 부른다
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);    //씬이름으로 로드
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    //빌드 인덱스로 로드
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }

        //메뉴 버튼 클릭시 호출
        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}