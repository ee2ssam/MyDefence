using UnityEngine;

namespace MyDefence
{
    //웨이브 데이터 관리하는 클래스
    [System.Serializable]
    public class Wave
    {
        //생성할 프리팹
        public GameObject enemyPrefab;
        //생성할 개체수
        public int count;
        //생성시 딜레이 타임
        public float delayTime;
        //...
    }
}
