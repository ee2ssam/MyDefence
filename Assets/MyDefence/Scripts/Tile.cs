using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    /// <summary>
    /// 맵 타일을 관리하는 클래스
    /// </summary>
    public class Tile : MonoBehaviour
    {
        #region Variables
        //BuildManager(싱글톤) 객체 선언
        private BuildManager buildManager;

        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;

        //타일에 설치된 타워 오브젝트 blueprint 객체(프리팹, 가격, 업그레이드 프리팹, 업그래이드 가격  설치조정위치...)
        public TowerBlueprint blueprint;

        //랜더러 컴포넌트 인스턴스 변수 선언
        private Renderer renderer;

        //마우스가 들어가면 바뀌는 컬러
        public Color hoverColor;
        //타일의 원래 색깔
        private Color startColor;

        //마우스가 들어가면 바뀌는 메터리얼
        public Material hoverMaterial;
        //건설 비용 부족시 바뀌는 메터리얼
        public Material moneyMaterial;

        //타일의 원래 메터리얼
        private Material startMaterial;

        //타워 건설 효과
        public GameObject buildEffectPrefab;
        //판매 효과
        public GameObject sellTowerPrefab;

        //타워 업그레이드 완료 여부 체크
        public bool isUpgradeCompleted = false;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            renderer = this.transform.GetComponent<Renderer>();
            buildManager = BuildManager.Instance;

            //초기화
            startColor = renderer.material.color;
            startMaterial = renderer.material;

        }

        private void OnMouseDown()
        {
            //UI로 가려져 있으면 설치 못한다
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //만약 타일에 타워오브젝트가 있으면 설치하지 못한다
            if (tower != null)
            {
                Debug.Log("타워오브젝트가 설치된 타일을 선택했습니다");
                buildManager.SelectTile(this);
                return;
            }

            //만약 타워를 선택하지 않았으면 설치하지 못한다
            if (buildManager.CannotBuild)
            {
                Debug.Log("설치할 타워가 없습니다");
                return;
            }

            blueprint = buildManager.GetTurretToBuild();

            //Debug.Log("마우스가 좌클릭하여 타일 선택 - 여기에 타워 건설");
            BuildTower();
        }

        private void OnMouseEnter()
        {
            //UI로 가려져 있으면 변경되지 않는다
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //만약 타워를 선택하지 않았으면 변경되지 않는다
            if (buildManager.CannotBuild)
            {   
                return;
            }

            //건설비용 체크
            if(buildManager.HasBuildCost)
            {
                //renderer.material.color = hoverColor;
                renderer.material = hoverMaterial;
            }
            else
            {
                renderer.material = moneyMaterial;
            }
        }

        private void OnMouseExit()
        {
            //renderer.material.color = startColor;
            renderer.material = startMaterial;
        }
        #endregion

        #region Custom Method
        //타워 건설
        private void BuildTower()
        {
            //건설비용 체크
            if(buildManager.HasBuildCost == false)
            {
                Debug.Log("건설 비용이 부족합니다");
                return;
            }

            //건설 비용 지불
            PlayerStats.UseMoney(blueprint.cost);

            //타워 건설
            tower = Instantiate(blueprint.prefab, this.transform.position + blueprint.offsetPos, Quaternion.identity);

            //건설 이펙트 효과 - 생성 후 2초 후 킬 예약
            GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //towerToBuild = null; 건설 후 다시 건설하지 못하게 한다
            buildManager.SetTurretToBuild(null);

            //Debug.Log($"건설하고 남은 소지금: {PlayerStats.Money}");
        }

        //업그레이드 타워
        public void UpgradeTower()
        {
            //Debug.Log("설치된 타워를 업그레이드 합니다");
            //업그레이드 비용 체크
            if(PlayerStats.HasMoney(blueprint.upgradeCost) == false)
            {
                Debug.Log("업그레이드 비용이 부족합니다");
                return;
            }

            //업그레이드 비용 처리
            PlayerStats.UseMoney(blueprint.upgradeCost);

            //업그레이드 완료 처리
            isUpgradeCompleted = true;

            //기존에 설치된 타워 킬
            Destroy(tower);

            //업그레이드 타워 건설
            tower = Instantiate(blueprint.upgradePrefab, this.transform.position + blueprint.offsetPos, Quaternion.identity);

            //건설/업그레이드 공유 이펙트 효과 - 생성 후 2초 후 킬 예약
            GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //선택된 타일 해제
            buildManager.DeselectTile();
        }

        //설치된 타워를 판매(제거)한다
        public void SellTower()
        {
            //Debug.Log("설치된 타워를 판매(제거) 합니다");

            //판매 가격 벌기
            PlayerStats.AddMoney(blueprint.GetSellCost());

            //업그레이드 완료 초기화
            isUpgradeCompleted = false;

            //타워 제거(킬)
            Destroy(tower);

            //판매 이펙트 효과 - 생성 후 2초 후 킬 예약
            GameObject effectGo = Instantiate(sellTowerPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //선택된 타일 해제
            buildManager.DeselectTile();
        }
        #endregion
    }
}
