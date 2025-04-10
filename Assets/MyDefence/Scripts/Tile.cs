using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    //맵의 타일을 관리하는 클래스
    public class Tile : MonoBehaviour
    {
        #region Field
        //마우스를 올려놓으면 변하는 색
        //public Color hoverColor;
        //타일의 원래 색깔
        //private Color startColor;

        //마우스를 올려놓으면 변하는 메터리얼(돈이 충분할때)
        public Material hoverMaterial;
        //마우스를 올려놓으면 변하는 메터리얼(돈이 부족할때)
        public Material moneyMaterial;

        //타일의 원래 메터리얼
        private Material startMaterial;

        //타일의 Renderer
        private Renderer renderer;

        //BuildManager 객체
        private BuildManager buildManager;

        //타일에 설치한 타워 오브젝트
        private GameObject tower;

        //타일에 설치한 타워의 정보
        private TowerBluePrint bluePrint;

        //타워 건설 이펙트 프리팹
        public GameObject buildEffectPrefab;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            buildManager = BuildManager.Instance;
            renderer = this.transform.GetComponent<Renderer>();

            //초기화
            //startColor = renderer.material.color;
            startMaterial = renderer.material;
        }

        private void OnMouseDown()
        {
            //타일위에 UI가 있는지 체크
            if(EventSystem.current.IsPointerOverGameObject() == true)
            {
                return;
            }

            //저장된 프리팹 체크
            if(buildManager.CannotBuild)
            {
                Debug.Log("설치할 타워가 없습니다");
                return;
            }

            //현재 타일에 타워가 설치되었는지 체크
            if(tower != null)
            {
                Debug.Log("타워를 설치할 수 없습니다");
                return;
            }

            //타워 건설
            BuildTower();
        }

        //타워 건설
        void BuildTower()
        {
            //건설비용 체크
            if (buildManager.NotEnoughMoney)
                return;

            //건설할 타워의 정보를 저장
            bluePrint = buildManager.GetTowerToBuild();
            
            //돈 계산
            PlayerStats.UseMoney(bluePrint.cost);

            //타일위에 터렛을 설치
            tower = Instantiate(bluePrint.towerPrefab, this.transform.position, Quaternion.identity);

            //건설 이펙트 생성한 후 2초후에 킬
            GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);
            
            //초기화 - 저장된 타워 정보를 초기화
            buildManager.SetTowerToBuild(null);

            Debug.Log($"건설하고 남은돈: {PlayerStats.Money}");
        }


        private void OnMouseEnter()
        {
            //타일위에 UI가 있는지 체크
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                return;
            }

            //저장된 프리팹 체크
            if (buildManager.CannotBuild)
            {
                //Debug.Log("설치할 타워가 없습니다");
                return;
            }

            //renderer.material.color = hoverColor;
            if(buildManager.NotEnoughMoney)
            {
                renderer.material = moneyMaterial;
            }
            else
            {
                renderer.material = hoverMaterial;
            }   
        }

        private void OnMouseExit()
        {
            //renderer.material.color = startColor;
            //renderer.material.color = Color.white;
            renderer.material = startMaterial;
        }
    }
}