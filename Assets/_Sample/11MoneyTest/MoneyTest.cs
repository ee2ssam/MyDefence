using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Sample
{
    public class MoneyTest : MonoBehaviour
    {
        #region Variables
        //소지금
        private int gold;
        //게임 시작시 지급하는 초기 소지금
        [SerializeField] private int startGold = 1000;

        //Money UI
        public TextMeshProUGUI moneyText;
        public Button button1000;
        public Button button9000;
        #endregion

        private void Start()
        {
            //초기화
            gold = startGold;
            Debug.Log($"소지금 {startGold}를 지급하였습니다");
        }

        private void Update()
        {
            //버튼 color
            if(HasMoney(1000))
            {
                button1000.image.color = Color.white;
            }
            else
            {
                button1000.image.color = Color.red;
            }

            if (HasMoney(9000))
            {
                button9000.image.color = Color.white;
            }
            else
            {
                button9000.image.color = Color.red;
            }

            //Money UI
            moneyText.text = gold.ToString() + " GOLD";
        }

        //Save1000 버튼 클릭시 호출
        public void Save1000()
        {            
            AddMoney(1000);
            //Debug.Log("1000 Gold Save");
        }

        //Purchase1000 버튼 클리시 호출 
        public void Purchase1000()
        {
            bool isUse = UseMoney(1000);

            if (isUse)
            {
                Debug.Log("1000 Item Purchase");
            }
        }

        //Purchase9000 버튼 클리시 호출
        public void Purchase9000()
        {
            if(UseMoney(9000))
            {
                Debug.Log("9000 Item Purchase");
            }
        }

        //돈을 번다 : 사냥, 퀘스트 클리어, 캐쉬 구매
        public void AddMoney(int amount)
        {
            gold += amount;
        }

        //돈을 쓴다: 아이템 구매, OO 사용료
        //돈이 부족하면 돈을 사용하지 않는다 return false
        //돈이 충분하면 돈을 사용한다 return true;
        public bool UseMoney(int amount)
        {
            //소지금 체크
            if (!HasMoney(amount))
            {
                Debug.Log("소지금이 부족합니다");
                return false;
            }

            gold -= amount;
            return true;
        }

        //소지금 잔금 확인
        public bool HasMoney(int amount)
        {
            return gold >= amount;
        }
    }
}