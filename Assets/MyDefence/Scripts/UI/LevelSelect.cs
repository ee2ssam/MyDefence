using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    public class LevelSelect : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        //레벨 선택 버튼s
        public Transform contents;      //레벨선택 버튼들의 부모 오브젝트
        private Button[] levelButtons;

        //자동 스크롤 계산
        public RectTransform scrollRect;
        public RectTransform contentsRect;
        public Scrollbar scrollbar;
        #endregion

        private void Start()
        {
            //게임실행시 처음으로 저장된 데이터(NowLevel) 가져오기
            int nowLevel = PlayerPrefs.GetInt("NowLevel", 1);
            Debug.Log($"NowLevel: {nowLevel}");

            //레벨 버튼s 초기화
            //레벨 버튼 배열 선언
            levelButtons = new Button[contents.childCount];
            //각 레벨 버튼 셋팅
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i] = contents.GetChild(i).GetComponent<Button>();
                if(i >= nowLevel)
                {
                    levelButtons[i].interactable = false;
                }
            }

            //현재 플레이할 레벨로 자동 스크롤
            float scrollHeight = scrollRect.rect.height;
            float contentsHeight = 110 + (int)((levelButtons.Length - 1)/5) *(110 + 6);
            //전체 스크롤 량
            float dHeight = contentsHeight - scrollHeight;
            if(dHeight > 0)
            {
                //현재 플레이할 레벨에 따른 스크롤 높이
                float nowLevelHeight = (int)((nowLevel - 1) / 5) * (110 + 6);
                if(nowLevelHeight < dHeight)
                {
                    scrollbar.value = 1 - (nowLevelHeight / dHeight);
                }
                else
                {
                    scrollbar.value = 0f;
                }   
            }
        }

        //레벨 버튼 클릭시 매개변수로 받은 씬이름으로 씬 이동한다
        public void LevelButtonSelect(string sceneName)
        {
            //Debug.Log($"{sceneName}씬으로 이동");
            fader.FadeTo(sceneName);
        }

        //메뉴가기
        public void ExitButton()
        {
            fader.FadeTo(loadToScene);
        }
    }
}


/*
게임 데이터 처리 : save / load
: 유저 데이터 - 유저가 게임을 플레이 하면서 생산한 데이터
: 게임 종료시에도 유지되어야 하는 데이터

- 파일 세이브 : 로컬 저장
1. 게임을 실행하면 저장된 게임 데이터가 있는지 없는지 파일 체크
파일이 없으면 - 유저 데이터들의 값을 초기 설정 데이터로 초기화 후 저장하여 파일을 만든다
파일이 있으면 - 파일을 읽어서 저장된 데이터로 유저 데이터들의 값을 초기화

2. 저장 위치/시점 고려

3. 저장시 저장된 데이터와 지금 저장할 데이터의 비교



//PlayerPrefs save/load
PlayerPrefs.SetInt(string KeyName, int Value); // KeyName 이름으로 Value 값 저장
PlayerPrefs.GetInt(string KeyName)         // KeyName 이름으로 저장된 값 가져오기

PlayerPrefs.SetFloat(string KeyName, float Value); // KeyName 이름으로 Value 값 저장
PlayerPrefs.GetFloat(string KeyName)         // KeyName 이름으로 저장된 값 가져오기

PlayerPrefs.SetString(string KeyName, string Value); // KeyName 이름으로 Value 값 저장
PlayerPrefs.GetString(string KeyName)         // KeyName 이름으로 저장된 값 가져오기
*/
