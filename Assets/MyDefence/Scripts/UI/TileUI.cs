using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence
{
    /// <summary>
    /// 타일 UI를 관리하는 클래스
    /// </summary>
    public class TileUI : MonoBehaviour
    {
        #region Variables
        //타일 UI 오브젝트
        public GameObject ui;

        //선택된 타일 저장
        private Tile targetTile;

        //업그레이드 가격 text
        public TextMeshProUGUI upgradeCostText;

        //업그레이드 버튼
        public Button upgradeButton;

        //판매 가격 text
        public TextMeshProUGUI sellCostText;
        #endregion

        #region Custom Method
        //타일 UI 보여주기(매개 변수로 선택된 타일 정보를 가져온다)
        public void ShowTileUI(Tile tile)
        {
            //내가 선택된 타일 위치에서 보여주기
            targetTile = tile;
            this.transform.position = tile.transform.position;

            //타일 UI value 셋팅
            if(targetTile.isUpgradeCompleted)
            {
                upgradeCostText.text = "DONE";
                upgradeButton.interactable = false;
            }
            else
            {
                upgradeCostText.text = targetTile.blueprint.upgradeCost.ToString() + " G";
                upgradeButton.interactable = true;
            }
            sellCostText.text = targetTile.blueprint.GetSellCost().ToString() + " G";

            ui.SetActive(true);
        }

        //타일 UI 숨기기
        public void HideTileUI()
        {
            targetTile = null;
            ui.SetActive(false);
        }

        //업그레이드 버튼을 선택했습니다.
        public void UpgradeTower()
        {
            targetTile.UpgradeTower();
        }

        //셀 버튼을 선택하였습니다.
        public void SellTower()
        {
            targetTile.SellTower();
        }
        #endregion
    }
}