using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 게임중 가지고 있는 Money를 그리는 UI 클래스
    /// </summary>
    public class DrawMoneyUI : MonoBehaviour
    {
        #region Variables
        //머니 UI
        public TextMeshProUGUI moneyText;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //Money 데이터 UI 적용
            moneyText.text = PlayerStats.Money.ToString();
        }
        #endregion
    }
}