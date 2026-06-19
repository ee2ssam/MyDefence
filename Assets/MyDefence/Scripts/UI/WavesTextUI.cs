using UnityEngine;
using TMPro;
using System.Collections;

namespace MyDefence
{
    /// <summary>
    /// 웨이브 숫자 텍스트 카운트 애니메이션 연출
    /// </summary>
    public class WavesTextUI : MonoBehaviour
    {
        #region Variables
        //웨이브 Text UI 인스턴스
        public TextMeshProUGUI wavesText;

        public int wavesCount = 16;

        // 총 카운트에 걸리는 시간(초)
        public float countDuration = 1f;

        // 텍스트 앞에 표시할 접두사 (예: "Wave ")
        public string prefix = "";
        #endregion

        //UI 활성화시 호출
        void OnEnable()
        {
            // 자동으로 연출 시작 (원치 않으면 Start 내부 호출을 제거)
            if (wavesText != null)
                SetWavesCountAndPlay(GameData.Waves);
        }

        /// <summary>
        /// 현재 설정된 wavesCount 값으로 카운트 연출을 시작합니다.
        /// </summary>
        public void Play()
        {
            if (wavesText == null)
                return;

            StopAllCoroutines();
            StartCoroutine(CountToCoroutine(wavesCount));
        }

        /// <summary>
        /// wavesCount 값을 설정하고 연출을 즉시 시작합니다.
        /// </summary>
        public void SetWavesCountAndPlay(int count)
        {
            wavesCount = Mathf.Max(0, count);
            Play();
        }

        IEnumerator CountToCoroutine(int target)
        {
            if (target <= 0)
            {
                wavesText.text = prefix + "0";
                yield break;
            }

            float interval = countDuration / Mathf.Max(1, target);

            for (int i = 1; i <= target; i++)
            {
                wavesText.text = prefix + i.ToString();
                yield return new WaitForSeconds(interval);
            }

            // 보정: 마지막 값 보장
            wavesText.text = prefix + target.ToString();
        }

    }
}