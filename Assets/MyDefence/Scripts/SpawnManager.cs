using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefence
{
    //적의 스폰을 관리하는 스크립트
    public class SpawnManager : MonoBehaviour
    {
        #region Variables
        //적 프리팹 원본 오브젝트 인스턴스
        public GameObject enemyPrefab;
        //스폰 위치(position)를 가지고 트랜스폼 인스턴스
        public Transform start;

        //스폰 타이머: 5초
        public float spawnTimer = 5f;   //타이머 기준 시간
        private float countdown = 0f;   //시간 누적 변수

        //웨이브 카운드
        private int waveCount = 0;
        //스폰 지연 시간
        public float spawnDelay = 0.5f;

        //UI - TMP의 인스턴스 
        public TextMeshProUGUI countdownText;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //[1]시작지점 위치에  Enemy 1개를 생성
            //EnemySpawn();

        }

        private void Update()
        {
            //[2]시점에서 5초 간격으로 Wave
            countdown += Time.deltaTime;
            if (countdown >= spawnTimer)
            {
                //타이머 실행문: Enemy Wave - 
                StartCoroutine(SpawnWave());

                //타이머 초기화
                countdown = 0f;
            }

            Debug.Log($"countdown:{countdown}");
            //countdownText.text = countdown.ToString();
            //countdownText.text = string.Format("{0:00.00}", countdown); //실수(소수점) 이하 출력
            countdownText.text = Mathf.Round(spawnTimer - countdown).ToString();       //정수(반올림하여) 출력

        }
        #endregion

        #region Custom Method
        //적 웨이브 구현 - 코루틴 함수로 구현
        IEnumerator SpawnWave()
        {
            waveCount++;
            Debug.Log($"{waveCount}번째 Wave");

            //waveCount 만큼 적 스폰하기
            for (int i = 0; i < waveCount; i++)
            {
                EnemySpawn();
                //약간 지연
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        //적 스폰하기
        void EnemySpawn()
        {
            Instantiate(enemyPrefab, start.position, Quaternion.identity);
        }
        #endregion
    }
}