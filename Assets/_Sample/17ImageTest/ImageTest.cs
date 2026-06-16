using UnityEngine;
using UnityEngine.UI;

namespace MySample
{
    /// <summary>
    /// 이미지 필 타입 예제 클래스
    /// 스킬 버튼 쿨 타임 구현
    /// </summary>
    public class ImageTest : MonoBehaviour
    {
        #region Variables
        public Button skillButton;

        //스킬 쿨 작동 여부
        private bool isCharge = false;

        [SerializeField]
        private float coolTimer = 5f;
        private float countdown = 0f;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //스킬 쿨 타이머
            if(isCharge)
            {
                countdown += Time.deltaTime;
                if (countdown >= coolTimer)
                {
                    //타이머 기능 작동
                    skillButton.interactable = true;

                    //타이머 초기화                    
                    isCharge = false;
                }

                //countdown으로 fillamount 구현
                // 0 -> 5 : 0 -> 1
                skillButton.image.fillAmount = countdown / coolTimer;
            }
        }
        #endregion

        #region Custom Method
        //스킬버튼 클릭
        public void SkillButton()
        {
            Debug.Log("사용 하였습니다");

            //스킬 기능 구현

            //쿨 타임 초기화
            skillButton.interactable = false;
            isCharge = true;
            countdown = 0f;
        }
        #endregion
    }
}