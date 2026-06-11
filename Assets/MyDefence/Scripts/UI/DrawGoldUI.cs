using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 골드 텍스트 출력
    /// </summary>
    public class DrawGoldUI : MonoBehaviour
    {
        //골드 텍스트 UI
        public TextMeshProUGUI goldText;

        // Update is called once per frame
        void Update()
        {
            goldText.text = GameData.Gold.ToString();
        }
    }
}