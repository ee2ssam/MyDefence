using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyDefence
{
    public class TileUI : MonoBehaviour
    {
        #region Field
        public GameObject offset;

        //선택한 타일 
        private Tile selectTile;

        //업그레이드 cost Text UI
        public TextMeshProUGUI upgradeCost;
        public Button upgradeButton;

        //판매 cost Txet UI
        public TextMeshProUGUI sellCost;
        #endregion

        //타일 UI 보이기
        public void ShowTileUI(Tile tile)
        {
            selectTile = tile;
            this.transform.position = selectTile.transform.position;

            if(selectTile.IsUpgrade)
            {
                //업그레이드 가격 표시
                upgradeCost.text = "COMPLETE";
                upgradeButton.interactable = false;
            }
            else
            {
                //업그레이드 가격 표시
                upgradeCost.text = tile.bluePrint.upgradeCost.ToString() + "G";
                upgradeButton.interactable = true;
            }

            //판매 가격 표시
            sellCost.text = tile.bluePrint.SellCost.ToString() + "G";

            offset.SetActive(true);
        }

        //타일 UI 감추기
        public void HideTileUI()
        {
            offset.SetActive(false);
        }

        //업그레이드 버튼 클릭시 호출
        public void UpgradeTower()
        {
            //선택된 타일에 있는 타워를 업그레이드 한다
            selectTile.UpgradeTower();

            //선택된 타일을 해제한다
            BuildManager.Instance.DeselectTile();
        }

        //셀 버튼 클릭시 호출
        public void SellTower()
        {
            //선택된 타일에 있는 타워를 판매한다
            selectTile.SellTower();

            //선택된 타일을 해제한다
            BuildManager.Instance.DeselectTile();
        }


    }
}