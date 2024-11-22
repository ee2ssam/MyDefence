using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class DrawMoneyUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI moneyText;
        #endregion

        // Update is called once per frame
        void Update()
        {
            moneyText.text = "G " + PlayerStats.Money.ToString();
        }
    }
}