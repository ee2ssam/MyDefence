using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    //씬 시작시 페이드인, 씬 종료시 페이드 아웃 효과 구현
    public class SceneFader : MonoBehaviour
    {
        #region Field
        //페이더 이미지
        public Image img;

        //애니메이션 커브
        public AnimationCurve curve;
        #endregion

        private void Start()
        {
            //페이드인
            StartCoroutine(FadeIn());
        }

        //코루틴으로 구현
        //FadeIn : 1초동안 : 검정에서 완전 투명으로 (이미지 알파값 a:1 -> a:0)
        IEnumerator FadeIn()
        {
            float t = 1f;

            while(t > 0)
            {
                t -= Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0f;    //한프레임 지연
            }
        }

        //FadeOut : 1초동안 : 투명에서 완전 검정으로 (이미지 알파값 a:0 -> a:1)
        IEnumerator FadeOut()
        {
            float t = 0f;

            while(t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0f;
            }
        }

        //FadeOut 효과 후 매개변수로 받은 씬이름으로 LoadScene으로 이동
        IEnumerator FadeOut(string sceneName)
        {
            //FadeOut 효과 후
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);

                yield return 0f;
            }

            //씬이동
            if(sceneName != "")
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        //다른 씬으로 이동시 호출
        public void FadeTo(string sceneName = "")
        {            
            StartCoroutine(FadeOut(sceneName));
        }

    }
}