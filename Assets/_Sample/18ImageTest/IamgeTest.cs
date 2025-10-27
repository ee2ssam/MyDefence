using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class IamgeTest : MonoBehaviour
    {
        #region Variables
        public Button skillButton;
        public Image buttonImage;

        //스킬 버튼 사용가능 여부 체크
        private bool isCharge = false;

        //쿨 타이머
        public float coolTimer = 5f;
        private float countdown = 0f;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            isCharge = true;
            countdown = 0f;
        }

        private void Update()
        {
            //스킬버튼 쿨 타이머
            if(isCharge == false)
            {
                countdown += Time.deltaTime;
                if (countdown >= coolTimer)
                {
                    //타이머 기능 - 스킬 활성화
                    isCharge = true;
                    skillButton.interactable = true;

                    //타이머 초기화
                    //countdown = 0f;
                }

                // 0 -> 1, countdown: 0 -> coolTimer
                // % : 현재값량 / 총값량
                buttonImage.fillAmount = countdown / coolTimer;
            }
        }
        #endregion

        #region Custom Method
        public void SkillButton()
        {
            if (isCharge == false)
                return;

            Debug.Log("스킬을 사용하였습니다");

            //스킬UI 초기화
            isCharge = false;
            skillButton.interactable = false;
            countdown = 0f;
        }
        #endregion
    }
}
