using UnityEngine;
using System;

namespace MyDefence
{
    /// <summary>
    /// 타워의 속성 데이터를 관리하는 (직렬화 된) 클래스
    /// </summary>
    [Serializable]
    public class TowerBlueprint
    {
        //건설
        public GameObject prefab;           //타워 건설에 필요한 프리팹 오브젝트
        public int cost;                    //타워 건설 비용

        //1차 업그레이드
        public GameObject upgradePrefab;    //타워 업그레이드에 필요한 프리팹 오브젝트
        public int upgradeCost;             //타워 업그레이드 비용

        //2차 업그레이드..

        //판매 가격
        public int GetSellCost() => cost / 2;

    }
}
