using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Sample
{
    public class InputTest : MonoBehaviour
    {
        //필드
        public TextMeshProUGUI xText;
        public TextMeshProUGUI yText;

        // Start is called before the first frame update
        void Start()
        {
            //스크린의 크기
            Debug.Log($"Screen Width : {Screen.width}");
            Debug.Log($"Screen Height : {Screen.height}");

        }

        // Update is called once per frame
        void Update()
        {

            //키보드 입력값 처리
            /*if(Input.GetKey("w"))
            {
                Debug.Log("w키를 누르고 있습니다");
            }
            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("w키를 눌렀습니다");
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                Debug.Log("w키에서 손을 떼었습니다");
            }*/

            //Inut Button
            /*if(Input.GetButton("Jump"))
            {
                Debug.Log("점프 버튼을 누르고 있습니다");
            }
            if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("점프 버튼을 눌렀습니다");
            }
            if(Input.GetButtonUp("Jump"))
            {
                Debug.Log("점프 버튼에서 손을 떼었습니다");
            }*/

            //Axis
            /*if(Input.GetButton("Horizontal"))
            {
                //left : -1 ~ 0
                //right : 0 ~ 1
                //float hValue = Input.GetAxis("Horizontal");                
                //Debug.Log($"Horizontal : {hValue}");

                //left : -1
                //right : 1
                float hValue = Input.GetAxisRaw("Horizontal");
                Debug.Log($"Horizontal Raw: {hValue}");
            }

            if(Input.GetButton("Vertical"))
            {
                //down : -1 ~ 0
                //up : 0 ~ 1
                float vValue = Input.GetAxis("Vertical");
                Debug.Log($"Vertical : {vValue}");
            }*/

            //마우스 위치값 얻어오기
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            //xText.text = "Mouse X: " + ((int)mouseX).ToString();
            //yText.text = "Mouse Y: " + ((int)mouseY).ToString();

            xText.text = ((int)mouseX).ToString() + ", " + ((int)mouseY).ToString();
            xText.rectTransform.position = new Vector2(mouseX, mouseY);
        }
    }
}