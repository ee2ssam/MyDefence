using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    public class CameraController : MonoBehaviour
    {
        //필드
        #region Variables
        //카메라 이동 속도
        public float moveSpeed = 10f;

        //경계 범위
        public float border = 10f;

        //줌 이동 속도
        public float zoomSpeed = 10f;
        public float minY = 10f;
        public float maxY = 40f;

        //이동 불가능: true,  이동가능:false;
        private bool isCannotMove = false;
        #endregion

        // Update is called once per frame
        void Update()
        {
            if (GameManager.IsGameOver)
                return;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isCannotMove = !isCannotMove;
            }

            if (isCannotMove)
                return;

            //wsad, arrow key 입력
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

            //마우스 위치값을 받아와서 맵 스크롤
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            if(mouseY >= (Screen.height - border) && mouseY < Screen.height)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseY >= 0 && mouseY < border)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX >= 0 && mouseX < border)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX >= (Screen.width-border) && mouseX < Screen.width)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            //마우스 휠 스크롤 값 처리 - 줌인 줌아웃
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            
            Vector3 zoomMove = this.transform.position;
            zoomMove.y -= (scroll * 1000) * Time.deltaTime * zoomSpeed;
            zoomMove.y = Mathf.Clamp(zoomMove.y, minY, maxY);
            this.transform.position = zoomMove;

        }
    }
}