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
        #endregion

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
        }

        private void OnDisable()
        {
            //new inputsystem class 객체 비활성화
            inputActions.Disable();
        }

        private void Update()
        {
            //wsad(arrow) 입력 값에 따른 카메라 이동
            Vector2 inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            //inputVector.x : a, d 입력값
            //inputVector.y : w, s 입력값
            //이동: 방향 * Time.delatTime * moveSpeed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            //MousePosition 값을 읽어서 카메라 이동 구현



            //space bar 입력 값에 따른 점프 버튼 처리
            /*bool isJump = inputActions.Camera.Jump.ReadValue<bool>();
            if (isJump)
            {
                Debug.Log("jump 버튼을 눌렀습니다");
            }*/

        }
        #endregion
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

3) Unity Event 등록 방법
*/
