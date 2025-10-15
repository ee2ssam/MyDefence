using UnityEngine;
using System;

namespace MyDefence
{
    /// <summary>
    /// 타워 데이터를 관리하는 (직렬화 된) 클래스
    /// </summary>
    [Serializable]
    public class TowerBlueprint
    {
        public GameObject prefab;   //타워 건설에 필요한 프리팹 오브젝트
        public int cost;            //타워 건설 비용
        public Vector3 offsetPos;   //타워 건설시 위치 조정 값

    }
}
