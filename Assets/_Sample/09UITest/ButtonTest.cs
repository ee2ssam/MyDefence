using UnityEngine;

namespace Sample
{
    //버튼 기능 테스트
    public class ButtonTest : MonoBehaviour
    {
        //Fire 버튼 클릭시 (실행)호출되는 함수
        public void FireButton()
        {
            Debug.Log("Fire 버튼을 눌렀습니다");
        }

        //점프 버튼 클릭시 "플레이어가 점프 하였습니다" 출력
        public void Jump()
        {
            Debug.Log("플레이어가 점프 하였습니다");
        }

    }
}