using UnityEngine;

namespace MyDefence
{
    //카메라를 제어하는 클래스
    public class CameraController : MonoBehaviour
    {
        #region Field
        //카메라 이동속도
        public float moveSpeed = 10f;

        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //W,S,A,D 키 (또는 키보드의 상하좌우 화살표)값을 받아
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            //마우스 포인터 위치 가져오기
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            //마우스 포인터가 스크린 상단에 위치하면
            if (mouseY >= (Screen.height - 10) && mouseY < Screen.height)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            //마우스 포인터가 스크린 하단에 위치하면
            if (mouseY <= 10 && mouseY > 0)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            //마우스 포인터가 스크린 좌측 끝에 위치하면
            if (mouseX <= 10 && mouseX > 0)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            //마우스 포인터가 스크린 우측 끝에 위치하면
            if (mouseX >= Screen.width - 10 && mouseX < Screen.width)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

        }
    }
}