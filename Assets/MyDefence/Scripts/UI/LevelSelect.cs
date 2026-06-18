using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    /// <summary>
    /// LevelSelect(레벨 선택) 씬을 관리하는 클래스
    /// </summary>
    public class LevelSelect : MonoBehaviour
    {
        #region Variables        
        //씬페이더 인스턴스
        public SceneFader fader;

        //레벨 버튼의 부모 트랜스폼 인스턴스
        public Transform content;

        //레벨 버튼 배열 인스턴스 선언
        private Button[] levelButtons;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //레벨 버튼 배열 초기화
            levelButtons = new Button[content.childCount];
            for (int i = 0; i < levelButtons.Length; i++)
            {
                Transform child = content.GetChild(i);
                levelButtons[i] = child.GetComponent<Button>();

                if(i > 0)
                    levelButtons[i].interactable = false;
            }

        }
        #endregion

        #region Custom Method
        //레벨 버튼 선택시 호출되는 메서드
        public void LevelButton(string loadToScene)
        {
            //선택한 레벨 씬으로 이동
            fader.FadeTo(loadToScene);
        }

        //뒤로가기 버튼 선택시 호출되는 메서드
        public void BackButton()
        {
            //메인메뉴 씬으로 이동
            fader.FadeTo("MainMenu");
        }
        #endregion
    }
}


/*
1. 유저 게임 데이터 : 유저가 게임 플레이하면 생산한 데이터
- 게임 어플리케이션 종료시에도 유지되어야 한다
- 세이브/로드
- 서버 저장, 파일시스템, PlayerPrefs

2. 세이브/로드 정책
1) 저장할 데이터
 - 클리어 레벨

2) 세이브 시점
 - 레벨 클리어시

3) 로드 시점
 - 레벨 셀렉트 씬 시작할때

3. 게임 데이터 로드시 체크 사항
- 저장파일 유무 체크
파일이 없으면 : 저장할 데이터를 설정 값으로 초기화
파일이 있으면 : 파일을 읽어서 읽어들인 값으로 초기화

4. 게임 데이터 세이브시 체크 사항
- 생산한 데이터와 저장된 데이터를 비교해서 저장해야 되는것을 체크
- 클리어 레벨 데이터는 저장된 데이터와 비교해서 저장된 데이터보다 크면 저장한다


PlayerPrefs save/load
PlayerPrefs.SetInt(KeyName, Value); //KeyName 이름으로 정수형 value 값 저장
PlayerPrefs.GetInt(KeyName);        //KeyName 이름으로 저장된 정수형 value 값 가져오기

PlayerPrefs.Setfloat(KeyName, Value); //KeyName 이름으로 실수형 value 값 저장
PlayerPrefs.Getfloat(KeyName);        //KeyName 이름으로 저장된 실수형 value 값 가져오기

PlayerPrefs.SetString(KeyName, Value); //KeyName 이름으로 문자열 value 값 저장
PlayerPrefs.GetString(KeyName);        //KeyName 이름으로 저장된 문자열 value 값 가져오기
*/