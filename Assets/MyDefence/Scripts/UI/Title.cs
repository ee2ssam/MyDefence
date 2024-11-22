using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";

        //GotoMenu 타이머
        [SerializeField] private float menuTimer = 10f;
        private float countdown = 0f;

        //showAnykey
        public GameObject anykeyText;
        [SerializeField] private float delayTime = 3.0f;
        private bool isShow = false;
        #endregion

        private void Start()
        {
            //초기화
            countdown = menuTimer;
            isShow = false;

            StartCoroutine(ShowAnyKey());
            //Invoke("ShowAnyKeyText", delayTime);

        }

        private void Update()
        {
            if (isShow == false)
                return;

            //10초후 GotoMenu
            /*if (countdown <= 0f)
            {
                //타이머 기능
                GotoMenu();
                return;

                //타이머 초기화
                //countdown = menuTimer;
            }
            countdown -= Time.deltaTime;*/

            //아무 키를 누르면 메인메뉴 씬 이동로 이동
            if (Input.anyKeyDown)
            {
                GotoMenu();
                StopAllCoroutines();
                return;
            }

            //....
        }

        void GotoMenu()
        {
            //Debug.Log("Goto MainMenu");
            SceneManager.LoadScene(loadToScene);
        }

        IEnumerator ShowAnyKey()
        {
            //3초 지연
            yield return new WaitForSeconds(delayTime);

            isShow = true;
            anykeyText.SetActive(true);

            //10초 지연
            yield return new WaitForSeconds(menuTimer);
            GotoMenu();
        }

        void ShowAnyKeyText()
        {
            isShow = true;
            anykeyText.SetActive(true);
        }
    }
}