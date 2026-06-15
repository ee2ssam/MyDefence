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
        //빌드매니저 싱글톤 인스턴스
        private BuildManager buildManager;

        //타일에 설치되는 타워의 Blueprint 변수
        //(건설 타워 정보, 업그레이 정보, 셀 정보)
        public TowerBlueprint blueprint;

        //타일에 설치되어 있는 타워의 게임오브젝트 인스턴스
        private GameObject tower;

        //타일 오브젝트의 랜더러 컴포넌트 인스턴스
        private Renderer renderer;

        //마우스가 들어가면 바뀌는 컬러
        public Color hoverColor;
        //마우스가 나오면 바뀌는 컬러 (메터리얼이 원래 가지고 있던 컬러)
        private Color originColor;

        //메터릴얼 변경
        public Material hoverMaterial;
        private Material originMaterial;

        //업그레이드 체크
        private bool isUpgrade;

        //이펙트
        public GameObject buildEffectPrefab;    //건설 또는 업그레이드시 이펙트 플레이
        public GameObject sellEffectPrefab;     //판매시 이펙트 플레이
        #endregion

        #region Property
        //업그레이드 비용 체크
        public bool HasUpgradeCost
        {
            get { return GameData.HasGold(blueprint.upgradeCost); }
        }

        //업그레이드 체크
        public bool IsUpgrade => isUpgrade;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            buildManager = BuildManager.Instance;
            renderer = this.transform.GetComponent<Renderer>();

            //필드 초기화
            //메터리얼이 원래 가지고 있던 컬러를 저장
            //originColor = renderer.material.color;
            originMaterial = renderer.material;
            isUpgrade = false;
        }

        private void OnMouseEnter()
        {
            //UI로 가려져 있는지 검증
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                //변경 실패
                return;
            }

            //타워 선택여부 검증
            if (buildManager.CannotBuild)
            {
                return;
            }

            //Debug.Log("타일에 들어간다, 연두색 변경");
            //renderer.material.color = hoverColor;
            renderer.material = hoverMaterial;
        }

        void OnMouseExit()
        {
            //Debug.Log("타일에 나온다, 원래 컬러로 변경 ");
            //renderer.material.color = originColor;
            renderer.material = originMaterial;
        }

        private void OnMouseDown()
        {
            //UI로 가려져 있는지 검증
            if(EventSystem.current.IsPointerOverGameObject() == true)
            {
                //설치 실패
                return;
            }

            //현재 타일에 타워가 설치되었는지 여부
            if (tower != null)
            {
                Debug.Log("타워가 설치되어있어 타일 UI를 보여준다");
                buildManager.SelectTile(this);
                return;
            }

            //타워 선택 여부 검증
            if (buildManager.CannotBuild)
            {
                //설치 실패
                Debug.Log("선택한 타워가 없어 설치하지 못했습니다");
                return;
            }

            //타워 정보를 저장
            blueprint = buildManager.GetSelectedTower();

            //타워 건설
            BuildTower();
        }
        #endregion

        #region Custom Method
        //타워 건설
        void BuildTower()
        {
            //건설 비용 체크
            if(buildManager.HasBuildCost == false)
            {
                Debug.Log("건설 비용이 부족합니다");
                return;
            }

            //건설 비용 결재
            GameData.UseGold(blueprint.cost);

            //Debug.Log("타일을 선택한다, 선택한 타워 설치");
            Vector3 offset = new Vector3(0f, 0.05f, 0f);
            tower = Instantiate(blueprint.prefab, this.transform.position + offset, Quaternion.identity);

            //이펙트: vfx, sfx
            if (buildEffectPrefab != null)
            {
                GameObject effectGo = Instantiate(buildEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effectGo, 3f);
            }

            //초기화
            buildManager.SetSelectedTower(null);
            //Debug.Log($"건설하고 남은 소지금: {GameData.Gold}");
        }

        //타워 업그레이드
        public void UpgradeTower()
        {
            //Debug.Log("설치된 타워 업그레이드");
            //업그레이드 비용 체크
            if (HasUpgradeCost == false)
            {
                Debug.Log("업그레드 건설 비용이 부족합니다");
                return;
            }

            //업그레드 비용 결재
            GameData.UseGold(blueprint.upgradeCost);

            //기존 타워 제거
            Destroy(tower);

            isUpgrade = true;

            //Debug.Log("타일을 선택한다, 선택한 타워 설치");
            Vector3 offset = new Vector3(0f, 0.05f, 0f);
            tower = Instantiate(blueprint.upgradePrefab, this.transform.position + offset, Quaternion.identity);

            //이펙트: vfx, sfx
            if (buildEffectPrefab != null)
            {
                GameObject effectGo = Instantiate(buildEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effectGo, 3f);
            }

            //buildManager 초기화            
            buildManager.DeSelectTile();
            //Debug.Log($"건설하고 남은 소지금: {GameData.Gold}");
        }

        //타워 판매하기
        public void SellTower()
        {
            //Debug.Log("설치된 타워 판매하기");

            //판매대금 받기
            GameData.AddGold(blueprint.GetSellCost());

            //타일 타워 초기화            
            Destroy(tower); //건설된 타워 제거
            blueprint = null;

            isUpgrade = false;

            //이펙트: vfx, sfx
            if (sellEffectPrefab != null)
            {
                GameObject effectGo = Instantiate(sellEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effectGo, 3f);
            }

            //buildManager 초기화
            buildManager.DeSelectTile();
        }
        #endregion

    }
}