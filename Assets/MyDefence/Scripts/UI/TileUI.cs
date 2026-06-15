using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence
{
    /// <summary>
    /// 타일 UI를 관리하는 클래스
    /// 선택된 타일의 정보(타일 위치, 타일 상태, 타일 blueprint)를 가져와서 구현
    /// </summary>
    public class TileUI : MonoBehaviour
    {
        #region Variables
        //타일 UI 오브젝트 - offset
        public GameObject ui;

        //선택된 타일 인스턴스
        private Tile selectedTile;

        //UI
        public TextMeshProUGUI upgradeCostText;
        public TextMeshProUGUI sellCostText;

        public Button upgradeButton;
        #endregion

        #region Custom Method
        //타일 UI 보여주기, UI 셋팅
        public void ShowTileUI(Tile tile)
        {
            selectedTile = tile;
            //선택된 타일의 위치로 조정
            this.transform.position = selectedTile.transform.position;

            //UI 셋팅
            //업그레이드 체크
            if(tile.IsUpgrade == true)
            {
                upgradeCostText.text = "DONE";
                upgradeButton.interactable = false;
            }
            else
            {
                upgradeCostText.text = selectedTile.blueprint.upgradeCost.ToString() + "G";
                upgradeButton.interactable = true;
            }

            sellCostText.text = selectedTile.blueprint.GetSellCost().ToString() + "G";

            ui.SetActive(true);
        }

        //타일 UI 숨기기
        public void HideTileUI()
        {
            selectedTile = null;
            ui.SetActive(false);
        }

        //타워 업그레이드
        public void UpgradeTower()
        {
            //Debug.Log("선택한 타일의 타워 업그레이드");
            selectedTile.UpgradeTower();
        }

        //타워 판매하기(제거하기)
        public void SellTower()
        {
            //Debug.Log("선택한 타일의 타워 판매하기");
            selectedTile.SellTower();
        }
        #endregion
    }
}