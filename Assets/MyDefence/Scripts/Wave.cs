using UnityEngine;
using System;

namespace MyDefence
{
    /// <summary>
    /// 웨이브 데이터를 관리하는 직렬화된 클래스
    /// </summary>
    [Serializable]
    public class Wave
    {
        public GameObject prefab;       //적 프리팹
        public int count;               //적 스폰 갯수
        public float delayTime;         //적 생성시 딜레이 타임
    }
}