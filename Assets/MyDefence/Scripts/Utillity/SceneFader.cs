using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 씬 페이드인, 페이드 아웃 기능
    /// 페이드 아웃 후 씬 이동
    /// </summary>
    public class SceneFader : MonoBehaviour
    {
        #region Variables
        public Image img;
        public AnimationCurve curve;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //시작하자 마자 페이드 인
            FadeStart();
        }
        #endregion

        #region Custom Method
        //페이드인 시작
        public void FadeStart(float delayTime = 0f)
        {
            StartCoroutine(FadeIn(delayTime));
        }

        //페이드인: 1초동안 이미지 a: 1 -> 0
        //페이드 시작전 매개변수로 받은 딜레이 시간 주기
        IEnumerator FadeIn(float delayTime)
        {
            //페이더 이미지를 검정색으로 시작
            img.color = new Color(0f, 0f, 0f, 1);
            //delayTime 체크
            if (delayTime >= 0f)
            {
                yield return new WaitForSeconds(delayTime);
            }

            float t = 1f;

            while (t > 0f)
            {
                t -= Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0;
            }
        }

        //페이드 아웃 이후 매개변수로 받은 씬이름으로 씬 이동
        public void FadeTo(string sceneName)
        {
            StartCoroutine(FadeOut(sceneName));
        }

        //페이드 아웃 이후 매개변수로 받은 씬 빌드번호으로 씬 이동
        public void FadeTo(int buildIndex)
        {
            StartCoroutine(FadeOut(buildIndex));
        }

        //페이드 아웃 : 1초동안 이미지 a: 0 -> 1
        IEnumerator FadeOut(string sceneName)
        {
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0;
            }

            //페이드 아웃 완료 후 다음씬으로 이동
            if(sceneName != string.Empty)
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        IEnumerator FadeOut(int buildIndex)
        {
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0;
            }

            //페이드 아웃 완료 후 다음씬으로 이동
            if (buildIndex >= 0)
            {
                SceneManager.LoadScene(buildIndex);
            }
        }
        #endregion
    }
}