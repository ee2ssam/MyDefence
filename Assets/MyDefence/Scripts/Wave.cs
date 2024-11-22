using UnityEngine;

namespace MyDefence
{
    //Wave 데이터를 관리하는 클래스
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;      //생성되는 Enemy 프리팹
        public int count;                   //생성되는 Enemy 수량
        public float delayTime;             //생성 지연 시간

        //...
    }
}