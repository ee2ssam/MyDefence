using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    /// <summary>
    /// 카메라 제어: 이동 - 뉴인풋시스템
    /// </summary>
    public class CameraControllerNew : MonoBehaviour
    {
        #region Variables
        //new inputsystem class 객체 선언
        private InputActionsTest inputActions;

        //카메라 이동속도
        public float moveSpeed = 10f;

        //카메라 이동 입력값 저장
        Vector2 inputVector;

        //마우스 위치 경계 변수
        public float border = 10f;
        #endregion

         
        //1) 스크립트를 이용하여 값 가져오기
        #region Unity Event Test
        private void Awake()
        {
            //참조
            //new inputsystem class 객체 생성
            inputActions = new InputActionsTest();
        }

        private void OnEnable()
        {
            //new inputsystem class 객체 활성화
            inputActions.Enable();
            inputActions.Camera.Jump.performed += Jump;
            //inputActions.Camera.Jump.started += Jump;
            //inputActions.Camera.Jump.canceled += Jump;
        }

        private void OnDisable()
        {
            //new inputsystem class 객체 비활성화
            inputActions.Disable();
            inputActions.Camera.Jump.performed -= Jump;
        }

        private void Update()
        {
            //wsad(arrow) 입력 값에 따른 카메라 이동: new inputsystem Class객체.액션맵이름.액션이름.ReadValue
            Vector2 inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            //inputVector.x : a, d 입력값
            //inputVector.y : w, s 입력값
            //이동: 방향 * Time.delatTime * moveSpeed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            //MousePosition 값을 읽어서 카메라 이동 구현
            //Vector2 mousePosition = inputActions.Camera.MousePosition.ReadValue<Vector2>();
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            float mouseX = mousePosition.x;
            float mouseY = mousePosition.y;

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
        }
        #endregion

        #region Custom Method
        public void Jump(InputAction.CallbackContext context)
        {
            //context.started   누르기 시작했을때
            //context.performed 눌렀을때 (1번 호출)
            //context.canceled    눌렀다가 뗄때
            Debug.Log("점프 버튼을 눌렀습니다");
        }
        #endregion


        //2) SendMessage 방법
        /* 
        #region Unity Event Method
        private void Update()
        {
            //카메라 이동
            //이동: 방향 * Time.delatTime * moveSpeed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
        }
        #endregion

        #region Custom Method
        public void OnMove(InputValue value)
        {
            inputVector = value.Get<Vector2>();
        }

        public void OnJump(InputValue value)
        {
            if(value.isPressed)
            {
                Debug.Log("점프 버튼을 눌렀습니다");
            }
        }
        #endregion
        */

        //3) Unity Event 등록 방법
        /*        
        #region Unity Event Method
        private void Update()
        {
            //카메라 이동
            //이동: 방향 * Time.delatTime * moveSpeed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
        }
        #endregion

        #region Custom Method
        public void Move(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            //context.started   누르기 시작했을때
            //context.performed 눌렀을때 (1번 호출)
            //context.canceled    눌렀다가 뗄때

            if(context.performed)
            {
                Debug.Log("점프 버튼을 눌렀습니다");
            }
        }
        #endregion
        */
    }
}


/*
1. Input Actions Editor 창 셋팅하기
- Action Maps 셋팅 (ex: Camera)
- Actions 셋팅 (ex: Move, Jump)
 
2. New Input System 에서 유저 인풋값 가져오기 - 3가지 방법
1) 스크립트를 이용하여 값 가져오기
- Input Actions 셋팅을 Class 파일로 만들어서 처리
- 만들어진 Class의 객체를 생성해서 인풋 값 처리

2) SendMessage 방법
- Player Input 컴포넌트 추가 : 액션맵 바인딩 - 드래그
- Behaviour를 SendMessage 셋팅
- 인풋 대응 함수 만들기
: 함수 이름 규칙: On + 액션이름 (InputValue value)


3) Unity Event 등록 방법
- Player Input 컴포넌트 추가 : 액션맵 바인딩 - 드래그
- Behaviour를 Unity Event 셋팅
- 인풋 대응 함수 만들기
- 이름 규칙 없음, 매개변수 규칙 있다
public void 함수이름 (InputAction.CallbackContext context)
- 만든 함수를 대응되는 이벤트에 등록한다
*/
