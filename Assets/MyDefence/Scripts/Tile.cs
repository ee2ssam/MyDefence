using UnityEngine;

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

        //마우스를 올려놓으면 변하는 메터리얼
        public Material hoverMaterial;
        //타일의 원래 메터리얼
        private Material startMaterial;

        //타일의 Renderer
        private Renderer renderer;

        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            renderer = this.transform.GetComponent<Renderer>();

            //초기화
            //startColor = renderer.material.color;
            startMaterial = renderer.material;
        }

        private void OnMouseDown()
        {
            //Debug.Log("이 스크립트가 붙어있는 타일위에 터렛을 설치");
            Instantiate(BuildManager.Instance.GetTowerToBuild(), this.transform.position, Quaternion.identity);
        }

        private void OnMouseEnter()
        {
            //renderer.material.color = hoverColor;
            renderer.material = hoverMaterial;
        }

        private void OnMouseExit()
        {
            //renderer.material.color = startColor;
            //renderer.material.color = Color.white;
            renderer.material = startMaterial;
        }
    }
}