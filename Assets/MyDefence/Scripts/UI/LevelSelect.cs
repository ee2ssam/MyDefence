using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    public class LevelSelect : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        //저장된 레벨 가져오기
        [SerializeField] private string keyName = "NowLevel";

        //레벨 버튼s 가져오기
        public Transform contents;
        private Button[] levelButtons;

        //스크롤
        public Scrollbar scrollbar;
        public RectTransform scrollView;
        public RectTransform contentsRect;
        #endregion

        private void Start()
        {
            //저장된 레벨(데이터) 가져오기
            int nowLevel = PlayerPrefs.GetInt(keyName, 1);
            //Debug.Log($"가져온 nowLevel: {nowLevel}");

            //레벨 버튼s 가져오기
            levelButtons = new Button[contents.childCount];
            //레벨 버튼s unlock
            for (int i = 0; i < levelButtons.Length; i++)
            {
                Transform child = contents.GetChild(i);
                levelButtons[i] = child.GetComponent<Button>();
                if(i < nowLevel)
                {
                    levelButtons[i].interactable = true;
                }
            }

            //자동 스크롤 높이
            float contentsHeight = 110 + (int)((levelButtons.Length - 1) / 5) * (110+5);
            float scrollHeight = contentsHeight - scrollView.rect.height;

            if (scrollHeight > 0)
            {
                float levelHeight = (int)(nowLevel - 1) / 5 * (110+5);
                scrollbar.value = 1 - levelHeight / scrollHeight;
                if(scrollbar.value < 0f)
                    scrollbar.value = 0f;
            }            
        }

        public void SelectLevel(string levelName)
        {
            //Debug.Log(levelName + " 버튼 클릭");
            fader.FadeTo(levelName);
        }
    }
}


/*
//게임데이터 Save/Load
- 로컬(디바이스) : 파일
- 서버 : 데이터베이스

PlayerPrefs
PlayerPrefs.SetInt(string KeyName, int Value);     //KeyName으로 value 값 저장하기(save)
PlayerPrefs.GetInt(string KeyName);            //KeyName으로 저장된 value 값 가져오기(load)
PlayerPrefs.SetFloat(string KeyName, float Value);     //KeyName으로 value 값 저장하기(save)
PlayerPrefs.GetFloat(string KeyName);            //KeyName으로 저장된 value 값 가져오기(load)
PlayerPrefs.SetString(string KeyName, string Value);     //KeyName으로 value 값 저장하기(save)
PlayerPrefs.GetString(string KeyName);            //KeyName으로 저장된 value 값 가져오기(load)

*/