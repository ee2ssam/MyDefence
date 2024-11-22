using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class ImageTest : MonoBehaviour
    {
        #region Variables
        public Image skillButtonImage;  //스킬 버튼 이미지
        public Button skillButton;      //스킬 버튼

        //스킬 쿨타이머
        [SerializeField] private float coolTimer = 5f;
        private float countdown = 0f;

        private bool isCharge = false;
        #endregion

        private void Start()
        {
            //초기화
            isCharge = true;
        }


        // Update is called once per frame
        void Update()
        {
            if (isCharge)
                return;

            //쿨 타이머
            countdown += Time.deltaTime;
            if (countdown >= coolTimer)
            {
                //스킬 활성화
                isCharge = true;
                skillButton.interactable = true;                

                //타이머 초기화
                //countdown = 0f;
            }

            // countdown 0 -> 5초 : 백분율 : 현재값(량) / 총값(량)
            skillButtonImage.fillAmount = countdown / coolTimer;

        }

        public void SkillUse()
        {
            //스킬효과
            Debug.Log("스킬 사용");

            //초기화
            skillButton.interactable = false;
            isCharge = false;
            countdown = 0f;
        }
    }
}