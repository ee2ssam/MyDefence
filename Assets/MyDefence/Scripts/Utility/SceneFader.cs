using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    //씬 시작시 페이드인, 씬 종료시 페이드 아웃 효과 구현
    public class SceneFader : MonoBehaviour
    {
        #region Field
        //페이더 이미지
        public Image img;
        #endregion

        //코루틴으로 구현
        //FadeIn : 1초동안 : 검정에서 완전 투명으로 (이미지 알파값 a:1 -> a:0)


        //FadeOut : 1초동안 : 투명에서 완전 검정으로 (이미지 알파값 a:0 -> a:1)


        //다른 씬으로 이동시 FadeOut 효과 후 LoadScene 으로 이동
    }
}