using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워 건설을 관리하는 싱글톤 클래스
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
            //DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Variables
        //선택한 타워 Blueprint - 타일에 설치할 프리팹 오브젝트, 건설비용, ....
        private TowerBlueprint selectedTower;

        //TileUI 인스턴스
        public TileUI tileUI;
        //선택한 타일의 인스턴스
        private Tile selectedTile;
        #endregion

        #region Property
        //타워 건설 가능 여부 체크, 읽기 전용 - true:건설불가능, false:건설 가능
        public bool CannotBuild
        {
            get { return selectedTower == null; }
        }

        //건설 비용 체크
        public bool HasBuildCost
        {
            get { return GameData.HasGold(selectedTower.cost);  }
        }
        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //선택한 타워 TowerBlueprint 인스턴스 반환
        public TowerBlueprint GetSelectedTower()
        {
            return selectedTower;
        }

        //선택한 타워의 TowerBlueprint를 매개변수로 받아 저장
        public void SetSelectedTower(TowerBlueprint tower)
        {
            selectedTower = tower;
        }

        //타일을 선택 - 선택한 타일의 인스턴스를 매개변수로 전달
        public void SelectTile(Tile tile)
        {
            //이미 선택되어 있다 && 이미 선택한 타일과 지금 선택한 타일이 같다면
            if(selectedTile == tile)
            {
                DeSelectTile();
                return;
            }

            //설치될 타워 정보 초기화
            selectedTower = null;

            selectedTile = tile;
            tileUI.ShowTileUI(tile);
        }

        //타일 선택 해제
        public void DeSelectTile()
        {
            //설치될 타워 정보 초기화
            selectedTower = null;

            selectedTile = null;
            tileUI.HideTileUI();
        }
        #endregion
    }
}