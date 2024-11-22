
using UnityEngine;

namespace MyDefence
{
    //빌드 메뉴에서 선택되는 터렛의 속성을 관리하는 클래스 - 직렬화된 클래스
    [System.Serializable]
    public class TurretBlueprint
    {
        public GameObject turretPrefab; //터렛 프리팹
        public int cost;                //터렛 건설 비용

        public GameObject turretUpgradePrefab;  //터렛 업그레이드 프리팹
        public int upgradeCost;                 //터렛 업그레이드 가격

        public Vector3 offset;          //터렛 건설 위치 보정값
        //....

        //판매 가격
        public int GetSellCost()
        {
            return cost / 2;
        }
    }
}