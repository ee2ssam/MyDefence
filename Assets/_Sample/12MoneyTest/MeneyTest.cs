using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Sample
{
    /// <summary>
    /// 소지금 연산 예제
    /// </summary>
    public class MeneyTest : MonoBehaviour
    {
        #region Variables
        //소지금
        private int gold;

        //초기 소지금
        [SerializeField]
        private int startGold = 1000;

        //소지금 UI Text
        public TextMeshProUGUI goldText;

        //구매버튼 UI
        public Button button1000;
        public Button button9000;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            //게임을 진행했으면 저장된 데이터를 가져와서 소지금을 초기화

            //게임을 다운로드 받고 처음 시작하면 지급
            gold = startGold;    //초기 소지금 지급
        }

        private void Update()
        {
            //소지금 체크하여 버튼 색 변경
            if (HasGold(1000))
            {
                //button1000.image.color = Color.white;
                button1000.interactable = true;
            }
            else
            {
                //button1000.image.color = Color.red;
                button1000.interactable = false;
            }

            if (HasGold(9000))
            {
                //button9000.image.color = Color.white;
                button9000.interactable = true;
            }
            else
            {
                //button9000.image.color = Color.red;
                button9000.interactable = false;
            }

            //소지금과 UI Text 연결
            goldText.text = gold.ToString() + " GOLD";
        }
        #endregion

        #region Custom Method
        public void Save1000()
        {
            Debug.Log("1000 Gold Save");
            AddGold(1000);
        }

        public void Purchase1000()
        {
            if(UseGold(1000) == true)
            {
                Debug.Log("1000 Item Purchase");
            }
        }

        public void Purchase9000()
        {
            if(UseGold(9000))
            {
                Debug.Log("9000 Item Purchase");
            }
        }

        //돈, Gold
        //돈을 번다: 사냥, 퀘스트, 캐쉬, 초기 소지금, 선물받기..
        public void AddGold(int amount)
        {
            gold += amount;
        }

        //돈을 쓴다: 아이템 구매, 기구 사용, 건설 비용, 선물하기..
        //돈이 부족하면 돈을 사용하지 않고 return false;
        //돈이 충분하면 돈을 사용하고 return true;
        public bool UseGold(int amount)
        {
            //소지금 체크
            if(gold < amount)
            {
                Debug.Log("소지금이 부족합니다");
                return false;
            }

            gold -= amount;
            return true;
        }

        //소지금 체크, 잔고 확인
        public bool HasGold(int amount)
        {
            return gold >= amount;
        }
        #endregion
    }
}