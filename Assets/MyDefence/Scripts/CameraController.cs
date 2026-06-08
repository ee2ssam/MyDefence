using UnityEngine;

namespace MyDefence
{
    public class CameraController : MonoBehaviour
    {
        #region Variables
        //카메라 이동
        public float moveSpeed = 10f;

        //화면 경계 테두리 두께
        public float border = 15f;

        //카메라 줌인, 줌아웃
        public float scrollSpeed = 10f;

        //카메라 이동 제어 변수
        private bool isCannotMove = false; //true: 이동 불능, false:이동 가능
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //카메라 이동 기능 막기
            //토글버튼 누르면 카메라 이동을 막는다 : isCannotMove:false -> isCannotMove:true
            //토글버튼 다시 누르면 카메라 이동한다 : isCannotMove:true -> isCannotMove:false
            if (Input.GetButtonDown("Esc Toogle"))
            {
                //Debug.Log("토글 버튼이 눌렸다");                
                isCannotMove = !isCannotMove;
            }

            //카메라 이동 제어 true: 이동 불능, false:이동 가능
            if (isCannotMove == true)
            {
                return; //return 이하 명령문을 실행하지 않는다
            }

            //키입력 처리(w,s,a,d - 상,하,좌,우)을 받아 카메라 이동 처리
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
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

            /*//마우스 위치 가져와서 카메라 이동 처리
            float mousePosX = Input.mousePosition.x;
            float mousePosY = Input.mousePosition.y;

            if (mousePosY >= (Screen.height - border) && mousePosY < Screen.height)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mousePosY > 0f && mousePosY <= border)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mousePosX > 0f && mousePosX <= border)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mousePosX >= (Screen.width - border) && mousePosX < Screen.width) 
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }*/

            //마우스 휠의 스크롤 값을 가져와서 카메라의 위 아래 이동 처리
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            //Debug.Log($"scroll: {scroll}");

            Vector3 cameraPosition = this.transform.position;
            //y축만 이동 연산 - 보정 계수 (1000) 적용
            cameraPosition.y -= (scroll * 1000f) * Time.deltaTime * scrollSpeed;
            //cameraPosition.y 최대값, 최소값 설정
            cameraPosition.y = Mathf.Clamp(cameraPosition.y, 10f, 25f);
            this.transform.position = cameraPosition;

        }
        #endregion

        #region Custom Method
        #endregion
    }
}