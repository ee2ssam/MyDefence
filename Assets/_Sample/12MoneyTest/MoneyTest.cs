using UnityEngine;
using MyDefence;
using TMPro;
using UnityEngine.UI;

namespace MySample
{
    /// <summary>
    /// 돈 계산 예제
    /// </summary>
    public class MoneyTest : MonoBehaviour
    {
        #region Variables
        //소지금 텍스트 UI 인스턴스
        public TextMeshProUGUI goldText;

        //구매 버튼 인스턴스
        public Button button1000;
        public Button button9000;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //소지금에 따른 구매 버튼 (컬러)상태 구현
            if(GameData.HasGold(1000))
            {
                button1000.image.color = Color.white;
            }
            else
            {
                button1000.image.color = Color.red;
            }
            //소지금에 따른 구매 버튼 (기능)상태 구현
            if (GameData.HasGold(9000))
            {
                button9000.interactable = true;
            }
            else
            {
                button9000.interactable = false;
            }



            //소지금을 텍스트 UI에 표시
            goldText.text = GameData.Gold.ToString() + " GOLD";
        }
        #endregion

        #region Custom Method
        //1000원 벌기 버튼
        public void Save1000()
        {            
            GameData.AddGold(1000);

            Debug.Log("1000 Gold Save");
        }

        //1000원 구매 버튼
        public void Purchase1000()
        {            
            if(GameData.UseGold(1000))
            {
                Debug.Log("1000 아이템 구매");
            }
        }

        //9000원 구매 버튼
        public void Purchase9000()
        {            
            if(GameData.UseGold(9000))
            {
                Debug.Log("9000 아이템 구매");
            }
        }
        #endregion

    }
}