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

        //타일 오브젝트의 랜더러 컴포넌트 인스턴스
        private Renderer renderer;

        //마우스가 들어가면 바뀌는 컬러
        public Color hoverColor;
        //마우스가 나오면 바뀌는 컬러 (메터리얼이 원래 가지고 있던 컬러)
        private Color originColor;

        //메터릴얼 변경
        public Material hoverMaterial;
        private Material originMaterial;
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
            if (buildManager.GetSelectedTower() == null)
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

            //타워 선택여부 검증
            if (buildManager.GetSelectedTower() == null)
            {
                //설치 실패
                //Debug.Log("선택한 타워가 없어 설치하지 못했습니다");
                return;
            }

            //Debug.Log("타일을 선택한다, 선택한 타워 설치");
            Vector3 offset = new Vector3(0f, 0.05f, 0f);
            Instantiate(buildManager.GetSelectedTower(), this.transform.position + offset, Quaternion.identity);

            //초기화
            buildManager.SetSelectedTower(null);
        }
        #endregion


    }
}