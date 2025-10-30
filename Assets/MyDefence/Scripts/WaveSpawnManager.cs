using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 적 스폰 및 웨이브를 관리하는 클래스
    /// </summary>
    public class WaveSpawnManager : MonoBehaviour
    {
        #region Variables
        //현재 살아있는 적의 수
        public static int enemyAlive = 0;

        //웨이브 데이터 셋팅: 프리팹, 생성갯수, 생성 딜레이
        public Wave[] waves;        // waves[0] ~ waves[4]

        //적 프리팹 오브젝트 - 원본
        public GameObject enemyPrefab;

        //public Transform start;  == this.transform

        //스폰 (5초) 타이머
        public float spawnTimer = 5f;      //타이머 기준 시간
        private float countdown = 0f;       //시간 누적 변수

        //웨이브 카운트
        private int waveCount = 0;

        //이번 웨이브에 생성되는 적의 수
        private int enemyCount = 0;

        //UI - Text
        public GameObject startButton;
        public GameObject waveCountUI;

        public TextMeshProUGUI waveCountText;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //EnemySpawn();
        }

        private void Update()
        {
            /*
            //스폰 (5초) 타이머
            countdown += Time.deltaTime;
            if (countdown >= spawnTimer)
            {
                //타이머 기능 실행
                WaveSpawn();

                //타이머 초기화
                countdown = 0f;
            }

            //UI - 카운트다운 텍스트
            //countdown 특정 범위(min, max) 설정 (- 값이 안되도록 설정)
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            //countdownText.text = string.Format("{0:00.00}", countdown); //실수(소수점 이하) 출력
            countdownText.text = Mathf.Round(countdown).ToString();       //반올림하여 정수 출력
            */

            if(enemyAlive <= 0)
            {
                if(startButton.activeSelf == false)
                {
                    WaveReady();
                }
            }
            else
            {
                waveCountText.text = enemyAlive.ToString() + " / " + enemyCount.ToString();
            }
        }
        #endregion

        #region Custom Method
        private void WaveSpawn()
        {
            StartCoroutine(SpawnWave());
        }

        //enemy 스폰 웨이브
        IEnumerator SpawnWave()
        {
            //waves[0], waves[1], waves[2], waves[3], waves[4]
            //웨이브 생성 데이터
            Wave wave = waves[waveCount];

            waveCount++;
            //웨이브 카운트
            PlayerStats.Rounds++;

            enemyCount = wave.count;
            enemyAlive = enemyCount;

            //wave 데이터로 생성
            for (int i = 0; i < wave.count; i++)
            {                
                EnemySpawn(wave.prefab);
                yield return new WaitForSeconds(wave.delayTime);  
            }
        }

        //시작점 위치에 enemy 1개 생성
        void EnemySpawn(GameObject prefab)
        {
            Instantiate(prefab, this.transform.position, Quaternion.identity);
        }

        //WaveStart 버튼 클릭시 호출
        public void WaveStart()
        {
            //UI 셋팅
            startButton.SetActive(false);
            waveCountUI.SetActive(true);

            //웨이브 시작
            WaveSpawn();
        }

        //웨이브 대기
        private void WaveReady()
        {
            //마지막 웨이브가 끝났는지 체크 - 웨이브 스폰 기능 정지
            if (waveCount >= waves.Length)
            {   
                GameManager.IsLevelClear = true;

                //UI 제거
                startButton.SetActive(false);
                waveCountUI.SetActive(false);

                this.enabled = false;
                return;
            }

            //UI 셋팅
            startButton.SetActive(true);
            waveCountUI.SetActive(false);
        }
        #endregion
    }
}