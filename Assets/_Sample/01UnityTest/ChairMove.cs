using UnityEngine;

public class ChairMover : MonoBehaviour
{
    // 의자의 이동 속도를 조절하는 변수예요.
    // Inspector 창(캐릭터 상세 설정창)에서 숫자를 마음대로 바꿀 수 있도록 public으로 선언했어요!
    public float moveSpeed = 5.0f;

    // Update는 게임이 실행되는 동안 '매 프레임(1초에 수십 번)'마다 계속 실행되는 함수예요.
    void Update()
    {
        // transform.Translate는 오브젝트를 이동시키는 명령어예요.
        // Vector3.forward : 앞쪽 방향으로 (0, 0, 1)
        // moveSpeed : 우리가 정한 속도만큼
        // Time.deltaTime : 컴퓨터 성능과 상관없이 일정하게 움직이도록 '시간 간격'을 곱해주는 유니티의 필수 공식!
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}