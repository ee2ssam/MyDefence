using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타일 UI를 관리하는 클래스
    /// </summary>
    public class TileUI : MonoBehaviour
    {
        #region Variables
        public GameObject ui;
        #endregion

        #region Custom Method
        //타일 UI 보여주기
        public void ShowTileUI()
        {
            ui.SetActive(true);
        }

        //타일 UI 숨기기
        public void HideTileUI()
        {
            ui.SetActive(false);
        }
        #endregion
    }
}