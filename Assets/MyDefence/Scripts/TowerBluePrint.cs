using UnityEngine;
using System;

namespace MyDefence
{
    //타워 속성(데이터) 정의 직렬화된 클래스
    [Serializable]
    public class TowerBluePrint
    {
        public GameObject towerPrefab;  //타워 건설에 필요한 프리팹
        public int cost;                //타워 건설 비용

        public GameObject upgradePrefab;    //타워 업그레이드에 필요한 프리팹
        public int upgradeCost;             //타워 업그레이드 비용

        //판매가격
        public int SellCost
        {
            get { return cost / 2; }
        }
        //public int sellCost;
        /*public int GetSellCost()
        {
            return cost / 2;
        }*/

        //....
    }

}