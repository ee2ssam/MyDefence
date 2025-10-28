using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 카메라 제어: 이동, 줌인,아웃 - 올드인풋시스템
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        #region Variables
        //카메라 앞뒤좌우 이동 속도
        public float moveSpeed = 10f;
        //카메라 위아래 이동 속도
        public float scrollSpeed = 10f;

        public float minPosY = 10f;     //카메라 최소 높이
        public float maxPosY = 40f;     //카메라 최대 높이

        //마우스 위치 경계 변수
        public float border = 10f;

        //카메라 이동 제어 체크 변수
        // true : 이동 불가능, false:이동 가능
        private bool isCannotMove = false;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //esc key를 한번 누르면 카메라 이동을 못하게 막는다 isCannotMove:false -> isCannotMove = true;
            //esc key를 다시 한번 누르면 카메라 이동을 하게 한다 isCannotMove:true -> isCannotMove = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Debug.Log("Input.GetKeyDown(KeyCode.Escape)");
                if (isCannotMove == false)
                {
                    isCannotMove = true;
                }
                else if (isCannotMove == true)
                {
                    isCannotMove = false;
                }
            }

            //카메라 이동 제어 체크 : true이면 return 아래 코드를 실행하지 말라
            if (isCannotMove)
                return;

            //w키(또는 상 방향키)를 입력하면 앞으로 이동
            //s키(또는 하 방향키)를 입력하면 뒤로 이동
            //a키(또는 좌 방향키)를 입력하면 왼쪽로 이동
            //d키(또는 우 방향키)를 입력하면 오른쪽으로 이동
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("앞으로 이동"); 방향 * Time.deltaTime * 속도
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("뒤로 이동"); 방향 * Time.deltaTime * 속도
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //Debug.Log("좌로 이동"); 방향 * Time.deltaTime * 속도
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("우로 이동"); 방향 * Time.deltaTime * 속도
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            /*
            //마우스를 스크린 상하좌우 끝 부분(기준 폭: 10)에 가져가면 맵을 스크롤 시킨다
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            //Debug.Log($"마우스 Position: {mouseX}, {mouseY}");
            if (mouseY >= (Screen.height - border) && mouseY <= Screen.height)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseY >= 0f && mouseY <= border)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX >= 0f && mouseX <= border)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX >= (Screen.width - border) && mouseX <= Screen.width)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }
            */

            //마우스 스크롤값을 입력 받아 줌인, 줌아웃 (높이 조절)기능 구현
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            //Debug.Log($"Mouse ScrollWheel: {scroll}");

            Vector3 upDownPosition = this.transform.position;
            //y축 이동만 연산 - 보정 계수 1000 적용
            upDownPosition.y -= (scroll * 1000) * Time.deltaTime * scrollSpeed;
            //카메라 최소,최대 높이 제한
            upDownPosition.y = Mathf.Clamp(upDownPosition.y, minPosY, maxPosY);
            this.transform.position = upDownPosition;


        }
        #endregion
    }
}