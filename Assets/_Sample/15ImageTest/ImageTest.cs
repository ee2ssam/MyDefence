using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    public class ImageTest : MonoBehaviour
    {

        #region Field
        //스킬 버튼
        public Button skillButton;
        public Image skillButtonImage;

        //쿨타이머
        [SerializeField]
        private float coolTime = 3f;
        private float countdown = 0f;

        //쿨 타임 체크
        private bool isCharge = false;
        #endregion

        private void Start()
        {
            //초기화
            countdown = 0f;
            isCharge = true;
        }

        private void Update()
        {
            if (isCharge)
                return;

            countdown += Time.deltaTime;
            if(countdown >= coolTime)
            {
                //타이머 기능
                skillButton.interactable = true;

                //타이머 초기화
                isCharge = true;
            }

            //countdown : 0->3, fillamunt 0->1 (100%, 소수점, 분수)
            //백분율: (현재값량: countdown) / (총값량:3) 3
            skillButtonImage.fillAmount = countdown / coolTime;

        }

        //스킬 버튼 클릭시 호출되는 함수
        public void SkillUse()
        {
            skillButton.interactable = false;

            //타이머 초기화
            countdown = 0;
            isCharge = false;
        }
    }
}