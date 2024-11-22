using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence
{
    public class TileUI : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;

        public GameObject tileUI;

        //선택받은 타일
        private Tile targetTile;

        //업그레이드 가격 텍스트, 버튼, 판매가격 텍스트
        public TextMeshProUGUI upgradeCost;
        public Button upgradeButton;
        public TextMeshProUGUI sellCost;
        #endregion

        private void Start()
        {
            //초기화
            buildManager = BuildManager.Instance;
        }

        //매개변수로 선택한 타일 정보를 얻어온다
        public void ShowTileUI(Tile tile)
        {
            //선택받은 타일 저장
            targetTile = tile;

            //터렛이 설치된 위치에서 보여준다
            this.transform.position = targetTile.GetBuildPosition();

            //업그레이드 가격 표시
            if(targetTile.IsUpgrade)
            {
                upgradeCost.text = "DONE";
                upgradeButton.interactable = false;
            }
            else
            {
                upgradeCost.text = targetTile.blueprint.upgradeCost.ToString() + " G";
                upgradeButton.interactable = true;
            }

            //판매 가격 표시
            sellCost.text = targetTile.blueprint.GetSellCost().ToString() + " G";

            tileUI.SetActive(true);
        }

        public void HideTileUI()
        {
            tileUI.SetActive(false);

            //선택받은 타일 초기화
            targetTile = null;
        }

        public void Upgrade()
        {
            targetTile.UpgradeTurret();
            buildManager.DeselectTile();
        }

        public void Sell()
        {            
            Debug.Log("Sell Turret");            
            targetTile.SellTurret();
            buildManager.DeselectTile();
        }
    }
}
