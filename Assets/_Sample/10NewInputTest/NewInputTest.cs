using UnityEngine;
using UnityEngine.InputSystem;

namespace MySample
{
    /// <summary>
    /// 게임중 유저 인풋 값을 New Input System 가져와서 적용하기
    /// 1) 스크립트를 이용하여 값 가져오기
    /// </summary>
    public class NewInputTest : MonoBehaviour
    {
        #region Variables
        //New Input System에서 만들어 클래스의 객체 선언
        private NewActionsTest inputActions;

        //카메라 이동
        public float moveSpeed = 10f;

        //화면 경계 테두리 두께
        public float border = 15f;

        //카메라 이동 제어 변수
        private bool isCannotMove = false; //true: 이동 불능, false:이동 가능
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            //New Input System에서 만들어 클래스의 객체 생성
            inputActions = new NewActionsTest();
        }

        private void OnEnable()
        {
            //New Input System에서 만들어 클래스의 객체 활성화
            inputActions.Enable();
            //버튼이 눌렸을때 호출되는 함수 등록
            inputActions.Camera.EscToggle.performed += Toggle;
            //inputActions.Camera.EscToggle.started += Toggle;
            //inputActions.Camera.EscToggle.canceled += Toggle;
        }

        private void OnDisable()
        {
            //New Input System에서 만들어 클래스의 객체 비활성화
            inputActions.Disable();
            //버튼이 눌렸을때 호출되는 함수 해제
            inputActions.Camera.EscToggle.performed -= Toggle;
            //inputActions.Camera.EscToggle.started -= Toggle;
            //inputActions.Camera.EscToggle.canceled -= Toggle;
        }

        private void Update()
        {
            //카메라 이동 제어 true: 이동 불능, false:이동 가능
            if (isCannotMove == true)
            {
                return; //return 이하 명령문을 실행하지 않는다
            }

            //wsad, arrow 입력값을 받아와서 카메라 이동
            //인스턴스이름.액션맵이름.액션이름.ReadValue<데이터타일>()
            Vector2 inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            //inputVector.x, inputVector.y

            //이동방향 * Time.deltaTime * speed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            this.transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            //마우스 위치 가져와서 카메라 이동 처리
            Vector2 mousePos = inputActions.Camera.MousePosition.ReadValue<Vector2>();
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
        public void Toggle(InputAction.CallbackContext context)
        {
            //context.started 누르기 시작했을때 1회 호출
            //context.canceled 눌렀다가 뗄때
            //context.performed 눌렀을때 1회 호출

            Debug.Log("토글버튼이 눌렸다");
            isCannotMove = !isCannotMove;
        }
        #endregion
    }
}

/*
New Input System

1. Input Action Editor 창 셋팅하기 (Action Map 설계)
- Action Map 설정(정의) - Player, UI, Camera
- Actions 설정(정의, input 값과 바인딩) - Move, Jump

2. 게임중 유저 인풋 값을 New Input System 가져와서 적용하기
1) 스크립트를 이용하여 값 가져오기 
- Input Action Editor 창에서 설정한 값을 Class 파일로 만들어서 처리
- 만들어진 Class의 객체(인스턴스)를 생성해서 인풋 처리

2) SendMessage 방법
- PlayerInput 컴포넌트를 대상 오브젝트에 추가한다
- Actions 에 설계한 Actions를 등록한다 (인스펙터 창에 드래그하여 바인딩)
- Behaviour를 Send Message로 설정한다
- 스크립트에 유저 인풋 값을 받아오는 함수를 만든다 (규칙에 맞게 만든다)
: 함수이름 : On + 액션이름(InputValue value)

3) Unity Event 등록 방법
- PlayerInput 컴포넌트를 대상 오브젝트에 추가한다
- Actions 에 설계한 Actions를 등록한다 (인스펙터 창에 드래그하여 바인딩)
- Behaviour를 Invoke Unity Event로 설정한다
- 스크립트에 유저 인풋 값을 받아오는 함수를 만든다 (규칙에 맞게 만든다)
: 함수 이름 규칙이 없음, 매개변수는 규칙이 있다
public void 함수이름 (InputAction.CallbackContext context)
- 만든 함수를 Action에 대응하는 이벤트에 등록한다
...
*/