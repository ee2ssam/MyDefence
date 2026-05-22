using UnityEngine;

namespace MySample
{
    //의자의 이동을 관리하는 클래스
    public class ChairMove : MonoBehaviour
    {
        // 의자의 이동 속도를 조절하는 변수예요.
        // 앞에 [SerializeField]를 붙이면 유니티의 'Inspector(상세 설정창)'에서 숫자를 마음대로 바꿀 수 있어요!
        [SerializeField]
        private float moveSpeed = 5.0f;

        // Update는 게임이 실행되는 동안 '매 프레임(아주 짧은 시간)'마다 계속 실행되는 함수예요.
        // 즉, 게임이 켜져 있는 동안 이 안의 명령을 멈추지 않고 계속 수행합니다.
        void Update()
        {
            // transform.Translate는 오브젝트를 이동시키는 명령어예요.
            // Vector3.forward는 유니티 세상에서 '앞방향(Z축)'을 뜻합니다.
            // Time.deltaTime은 컴퓨터 성능이 달라도 모두 똑같은 속도로 움직이게 만들어주는 '시간 조정 가위' 같은 역할이에요.
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}