using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace MyDefence
{
    //카메라를 제어하는 클래스
    public class CameraController : MonoBehaviour
    {
        #region Field
        //카메라 이동속도
        public float moveSpeed = 10f;

        //카메라 스크롤 스피드
        public float scrollSpeed = 10f;
        public float scrollMin = 10f;
        public float scrollMax = 40f;

        //카메라 컨트롤 제어 유무 (true이면 못 움직인다, false: 움직인다)
        public bool isCannotMove = false;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            isCannotMove = false;
        }

        // Update is called once per frame
        void Update()
        {
            //esc key를 한번 누르면 카메라 이동을 못하게 막는다 isCannotMove = true (!isCannotMove)
            //esc key를 다시 한번 누르면 카메라 이동을 하게 한다 isCannotMove = false (!isCannotMove)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isCannotMove = !isCannotMove;   //토글 기능
            }

            //isCannotMove가 true이면 return 아래 코드를 실행하지 말라
            if (isCannotMove)
                return;

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

            //마우스 휠을 스크롤하면 화면이 줌인 줌아웃 한다 
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            //Debug.Log($"ScrollWheel: {scroll}");
            Vector3 upMove = this.transform.position;
            upMove.y -= (scroll * 1000) * Time.deltaTime * scrollSpeed;            
            upMove.y = Mathf.Clamp(upMove.y, scrollMin, scrollMax); //(upMove.y : 10f 이상, 40f 이하)
            this.transform.position = upMove;

        }
    }
}