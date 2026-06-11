using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 라이프 갯수 텍스트 출력
    /// </summary>
    public class DrawLivesUI : MonoBehaviour
    {
        //라이프 텍스트 UI
        public TextMeshProUGUI livesText;

        // Update is called once per frame
        void Update()
        {
            livesText.text = GameData.Lives.ToString();
        }
    }
}