using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    //뉴인풋 시스템으로 카메라 제어
    public class CameraController : MonoBehaviour
    {
        #region Variables
        private MyInputAction inputActions;

        //카메라 이동 속도
        public float moveSpeed = 10f;

        //경계 범위
        public float border = 10f;

        //
        private Vector2 inputVector;
        private Vector2 mousePos;

        //줌 이동 속도
        public float zoomSpeed = 10f;
        public float minY = 10f;
        public float maxY = 40f;
        #endregion

        //스크립트 적용시
        private void Awake()
        {
            inputActions = new MyInputAction();
        }

        private void OnEnable()
        {
            inputActions.Enable();
            //inputActions.Camera.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
            //inputActions.Camera.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            //Camera Move
            inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            //마우스 위치 가져오기
           //mousePos = Mouse.current.position.ReadValue();
           mousePos = inputActions.Camera.MousePos.ReadValue<Vector2>();
            if (mousePos.y >= (Screen.height - border) && mousePos.y < Screen.height)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mousePos.y >= 0 && mousePos.y < border)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mousePos.x >= 0 && mousePos.x < border)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mousePos.x >= (Screen.width - border) && mousePos.x < Screen.width)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            //휠 스크롤
            Vector2 scroll = Mouse.current.scroll.ReadValue();

            Vector3 zoomMove = this.transform.position;
            zoomMove.y -= (scroll.y) * Time.deltaTime * zoomSpeed;
            zoomMove.y = Mathf.Clamp(zoomMove.y, minY, maxY);
            this.transform.position = zoomMove;
        }

        //unity Event - 메서드 등록 실행
        public void Move(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

        public void MousePos(InputAction.CallbackContext context)
        {
            mousePos = context.ReadValue<Vector2>();
        }

        //sendMessages 이용 : 함수이름 - On + 액션이름 - 알아서 찾아 실행
        public void OnMove(InputValue value)
        {
            inputVector = value.Get<Vector2>();
        }

        public void OnMousePos(InputValue value)
        {
            mousePos = value.Get<Vector2>();
        }

    }
}