using System;
using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 웨이브 데이터를 관리하는 직렬화된 클래스
    /// </summary>
    [Serializable]
    public class Wave
    {
        public GameObject prefab;       //스폰할 적의 프리팹
        public int count;               //스폰할 적의 수
        public float delayTime;         //적 스폰 간의 지연 시간
    }
}
