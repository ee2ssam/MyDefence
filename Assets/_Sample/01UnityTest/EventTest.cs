using UnityEngine;

namespace MySample
{
    //유니티 MonoBehaviour 스크립트 이벤트 함수 테스트
    public class EventTest : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("[1] Awake 실행");  //1회만 실행, 가장 먼저 실행
        }

        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnable 실행"); //(활성화 될때마다) 1번만 실행
        }

        private void Start()
        {
            Debug.Log("[2] Start 실행");  //1회만 실행
        }

        private void FixedUpdate()
        {
            Debug.Log("[3] FixedUpdate 실행");    //1초에 50번 고정 호출, 물리 연산
        }

        private void Update()
        {
            Debug.Log("[4] Update 실행");     //매 프레임마다 호출, 게임 로직 연산
        }

        private void LateUpdate()
        {
            Debug.Log("[5] LateUpdate 실행");     //Update() 실행 뒤에 바로 따라서 실행, 카메라 움직임 연산
        }

        private void OnDisable()
        {
            Debug.Log("[7-1] OnDisable 실행");    //(비 활성화 될때마다) 1번 실행
        }

        private void OnDestroy()
        {
            Debug.Log("[6] OnDestroy 실행");  //하이라키창에서 없어질때(킬) 호출
        }

    }
}

