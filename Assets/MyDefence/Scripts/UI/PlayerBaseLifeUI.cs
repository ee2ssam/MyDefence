using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class PlayerBaseLifeUI : MonoBehaviour
    {
        #region Field
        //Lives Text UI
        public TextMeshProUGUI livesText;
        #endregion


        // Update is called once per frame
        void Update()
        {
            livesText.text = PlayerStats.Lives.ToString();
        }
    }
}