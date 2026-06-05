using UnityEngine;
using TMPro; // 💡 아주 중요! 일반 UI 대신 TextMeshPro를 제어하기 위한 전용 네임스페이스예요.

namespace MySample
{
    public class UIManager : MonoBehaviour
    {
        // [변수 배역 소개]
        // 💡 기존 'Text' 대신 'TextMeshProUGUI'라는 자료형을 사용합니다. 
        // Canvas(화면) 위에 그리는 TMP 텍스트는 꼭 뒤에 UGUI가 붙은 이 자료형을 써야 해요!
        public TextMeshProUGUI scoreText;

        private int currentScore = 0; // 현재 점수를 저장할 비밀 금고

        // 게임이 처음 시작될 때 실행되는 곳
        void Start()
        {
            // 게임 시작하자마자 화면에 "SCORE : 0"을 먼저 보여줍니다.
            UpdateScoreUI();
        }

        // 🚀 Fire 버튼을 눌렀을 때 실행할 함수
        public void OnFireButtonClicked()
        {
            Debug.Log("발사 하였습니다");
        }

        // 🦘 Jump 버튼을 눌렀을 때 실행할 함수
        public void OnJumpButtonClicked()
        {
            Debug.Log("플레이어가 점프하였습니다");

            // 점수를 10점 더하기
            currentScore += 10;

            // 더해진 점수를 화면에 새로고침하기
            UpdateScoreUI();
        }

        // 텍스트 UI의 글자를 새로 쓰는 기능
        void UpdateScoreUI()
        {
            // 변수 타입은 바뀌었지만, 글자를 바꾸는 방식(.text)은 기존과 똑같답니다!
            scoreText.text = "SCORE : " + currentScore.ToString();
        }
    }
}