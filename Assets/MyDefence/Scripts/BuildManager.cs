using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    /// <summary>
    /// 타워를 건설을 관리하는 싱글톤 클래스
    /// </summary>
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }
        #endregion

        #region Variables
        //타일에 설치할 타워 blueprint(프리팹, 가격, 위치정보...)를 저장하는 변수
        //여러개의 타워 blueprint중 선택된 타워 blueprint을 저장하는 변수
        private TowerBlueprint towerToBuild;

        //타일 UI
        public TileUI tileUI;

        //선택된 타일 저장(타일 UI가 있는 타일)
        private Tile selectTile;
        #endregion

        #region Property
        //건설 불가능 여부 체크: 선택되지 않았으면
        public bool CannotBuild
        {
            get { return towerToBuild == null; }
        }

        //건설 비용 부족 체크
        public bool HasBuildCost
        {
            get
            {
                //선택되지 않았으면
                if(towerToBuild == null)
                    return false;

                return PlayerStats.HasMoney(towerToBuild.cost);
            }
        }
        #endregion

        #region Unity Event Method        
        #endregion

        #region CustomMethod
        public TowerBlueprint GetTurretToBuild()
        {
            return towerToBuild;
        }

        public void SetTurretToBuild(TowerBlueprint tower)
        {
            towerToBuild = tower;
        }

        //타워오브젝트가 설치된 타일을 선택, 선택된 타일 정보를 매개변수로 받아온다
        public void SelectTile(Tile tile)
        {
            //저장된 타일과 선택된 타일 체크
            if(tile == selectTile)
            {                
                DeselectTile();
                return;
            }

            //설치될 타워 정보 초기화
            towerToBuild = null;

            selectTile = tile;
            tileUI.ShowTileUI(selectTile);
        }

        //선택된 타일 해제, 선택된 타일 초기화
        public void DeselectTile()
        {
            //설치될 타워 정보 초기화
            towerToBuild = null;

            tileUI.HideTileUI();
            selectTile = null;
        }
        #endregion
    }
}
