using UnityEngine;
using UnityEngine.InputSystem;

namespace MySample
{
    /// <summary>
    /// 게임중 유저 인풋 값을 New Input System 가져와서 적용하기
    /// 3) Unity Event 등록 방법
    /// </summary>
    public class NewInputTest3 : MonoBehaviour
    {
        #region Variables
        //New Input System에서 만들어 클래스의 객체 선언
        private NewActionsTest inputActions;

        //카메라 이동
        public float moveSpeed = 10f;
        private Vector2 inputVector = Vector2.zero;

        //화면 경계 테두리 두께
        public float border = 15f;
        private Vector2 mousePos = Vector2.zero;

        //카메라 이동 제어 변수
        private bool isCannotMove = false; //true: 이동 불능, false:이동 가능
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //카메라 이동 제어 true: 이동 불능, false:이동 가능
            if (isCannotMove == true)
            {
                return; //return 이하 명령문을 실행하지 않는다
            }

            //wsad, arrow 입력값을 받아와서 카메라 이동
            //이동방향 * Time.deltaTime * speed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            this.transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            //
            float mousePosX = mousePos.x;
            float mousePosY = mousePos.y;

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
            }

        }
        #endregion

        #region Custom Method
        //상하좌우 wasd 입력 처리
        public void OnMove(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }
        

        //마우스 위치 입력 처리
        public void OnMousePostion(InputAction.CallbackContext context)
        {
            mousePos = context.ReadValue<Vector2>();
        }

        //토글 버튼 입력 처리
        public void OnEscToggle(InputAction.CallbackContext context)
        {
            //context.started 누르기 시작했을때 1회 호출
            //context.canceled 눌렀다가 뗄때
            //context.performed 눌렀을때 1회 호출

            if(context.performed)
            {
                Debug.Log("토글버튼이 눌렸다");
                isCannotMove = !isCannotMove;
            }
        }
        #endregion
    }
}