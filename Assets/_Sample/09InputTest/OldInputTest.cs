using UnityEngine;

namespace MySample
{
    /// <summary>
    /// old Input test 예제
    /// </summary>
    public class OldInputTest : MonoBehaviour
    {
        #region Variables
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //스크린 크기 값 가져오기
            Debug.Log($"Screen Width: {Screen.width}");
            Debug.Log($"Screen Heigth: {Screen.height}");

        }

        private void Update()
        {
            //키입력 체크 - w키 입력
            /*if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("w키를 누르고 있습니다");
            }
            if(Input.GetKeyDown("w"))
            {
                Debug.Log("w키를 눌렀습니다");
            }
            if(Input.GetKeyUp("w"))
            {
                Debug.Log("w키를 눌렀다가 떼었습니다");
            }*/

            //GetButton - InputManager에 정의되어 있는 Buttons(Axes) 의 이름을 가져와서 사용한다
            //버튼의 이름은 문자열로 가져온다
            /*if(Input.GetButton("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)을 누르고 있습니다");
            }
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)을 눌렀습니다");
            }
            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)을 눌렀다가 떼었습니다");
            }*/

            /*//GetAxis - InputManager에 정의되어 있는 Axes(Buttons) 의 이름을 가져와서 사용한다
            //a, left : -1~0
            //d, right : 0~1
            float hValue = Input.GetAxis("Horizontal");
            Debug.Log($"Horizontal GetAxis value: {hValue}");

            //s, down : -1~0
            //w, up : 0~1
            float vValue = Input.GetAxis("Vertical");
            Debug.Log($"Vertical GetAxis value: {vValue}");*/

            //스크린상의 마우스 위치값 가져오기
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            Debug.Log($"Mouse Postion: ({mouseX}, {mouseY})");
        }
        #endregion
    }
}
