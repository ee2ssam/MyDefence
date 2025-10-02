using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 맵 타일을 관리하는 클래스
    /// </summary>
    public class Tile : MonoBehaviour
    {
        #region Variables
        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;

        //랜더러 컴포넌트 인스턴스 변수 선언
        private Renderer renderer;

        //마우스가 들어가면 바뀌는 컬러
        public Color hoverColor;
        //타일의 원래 색깔
        private Color startColor;

        //마우스가 들어가면 바뀌는 메터리얼
        public Material hoverMaterial;
        //타일의 원래 메터리얼
        private Material startMaterial;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            renderer = this.transform.GetComponent<Renderer>();

            //초기화
            startColor = renderer.material.color;
            startMaterial = renderer.material;

        }

        private void OnMouseDown()
        {
            //만약 타일에 타워오브젝트가 있으면 설치하지 못한다
            if (tower != null)
            {
                Debug.Log("타워를 설치하지 못합니다");
                return;
            }

            //Debug.Log("마우스가 좌클릭하여 타일 선택 - 여기에 타워 건설");
            tower = Instantiate(BuildManager.Instance.GetTurretToBuild(), this.transform.position, Quaternion.identity);
        }

        private void OnMouseEnter()
        {
            //renderer.material.color = hoverColor;
            renderer.material = hoverMaterial;
        }

        private void OnMouseExit()
        {
            //renderer.material.color = startColor;
            renderer.material = startMaterial;
        }
        #endregion
    }
}
