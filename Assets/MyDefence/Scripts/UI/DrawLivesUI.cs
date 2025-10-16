using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 게임중 가지고 있는 Life 갯수를 그리는 UI 클래스
    /// </summary>
    public class DrawLivesUI : MonoBehaviour
    {
        #region Variables
        //Life UI : 생명 갯수
        public TextMeshProUGUI livesCount;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //Life 데이터 UI 적용
            livesCount.text = PlayerStats.Lives.ToString();
        }
        #endregion
    }
}