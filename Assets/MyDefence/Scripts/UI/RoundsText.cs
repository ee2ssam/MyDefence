using System.Collections;
using UnityEngine;
using TMPro;

namespace MyDefence
{
    //라운드 숫자 텍스트 카운팅 애니메이션 연출
    public class RoundsText : MonoBehaviour
    {
        #region Field
        public TextMeshProUGUI roundsText;
        #endregion

        private void OnEnable()
        {
            //애니 연출 시작
            StartCoroutine(AnimateNumberText(PlayerStats.Rounds));
        }

        //매개변수로 받은 숫자를 UI 텍스트에서 애니메이션 연출
        IEnumerator AnimateNumberText(int targetNumber)
        {
            int aniNumber = 0;
            roundsText.text = aniNumber.ToString();
            yield return new WaitForSeconds(0.1f);

            while (aniNumber < targetNumber)
            {
                aniNumber++;
                roundsText.text = aniNumber.ToString();
                yield return new WaitForSeconds(0.05f);
            }

            //애니 연출 종료
        }
    }
}
