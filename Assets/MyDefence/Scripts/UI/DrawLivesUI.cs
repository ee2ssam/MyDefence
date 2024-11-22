using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class DrawLivesUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI livesText;
        #endregion

        // Update is called once per frame
        void Update()
        {
            livesText.text = PlayerStats.Lives.ToString();
        }
    }
}