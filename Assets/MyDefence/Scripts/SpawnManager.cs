using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefence
{
    //적의 스폰을 관리하는 스크립트
    public class SpawnManager : MonoBehaviour
    {
        #region Variables
        //웨이브 데이터
        public Wave[] waves;              //웨이브 데이터 배열

        //적 프리팹 원본 오브젝트 인스턴스
        //public GameObject enemyPrefab;
        //스폰 위치(position)를 가지고 트랜스폼 인스턴스
        public Transform start;

        //스폰 타이머: 5초
        //public float spawnTimer = 5f;   //타이머 기준 시간
        //private float countdown = 0f;   //시간 누적 변수

        //웨이브 카운드
        private int waveCount = 0;
        //스폰 지연 시간
        //public float spawnDelay = 0.5f;

        private int enemyMax = 0;                   //이번 웨이브에서 스폰할 적의 최대 수
        public static int enemyAlive = 0;           //현재 웨이브에서 살아있는 적의 수

        //UI - TMP의 인스턴스 
        //public TextMeshProUGUI countdownText;
        public GameObject startButton;              //wave 시작 버튼
        public GameObject waveInfoUI;               //wave 정보 UI
        public TextMeshProUGUI waveCountText;       //enemy 갯수 정보 텍스트
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //[1]시작지점 위치에  Enemy 1개를 생성
            //EnemySpawn();

        }

        private void Update()
        {
            //UI
            if(enemyAlive <= 0)
            {
                ReadyWave();
            }
            else
            {
                waveCountText.text = enemyAlive.ToString() + " / " + enemyMax.ToString();
            }

            //[2]시점에서 5초 간격으로 Wave
            /*countdown += Time.deltaTime;
            if (countdown >= spawnTimer)
            {
                //타이머 실행문: Enemy Wave - 
                StartCoroutine(SpawnWave());

                //타이머 초기화
                countdown = 0f;
            }*/

            //Debug.Log($"countdown:{countdown}");
            //countdownText.text = countdown.ToString();
            //countdownText.text = string.Format("{0:00.00}", countdown); //실수(소수점) 이하 출력
            //countdownText.text = Mathf.Round(spawnTimer - countdown).ToString();       //정수(반올림하여) 출력
        }
        #endregion

        #region Custom Method
        //StartWave 버튼 클릭시 호출
        public void StartWave()
        {
            //Enemy Wave
            StartCoroutine(SpawnWave());

            //UI
            startButton.SetActive(false);
            waveInfoUI.SetActive(true);
        }

        //적 웨이브 구현 - 코루틴 함수로 구현
        IEnumerator SpawnWave()
        {
            //waves[0] 웨이브 데이터를 가져와서 wave
            //wave : 이번에 웨이브할 데이터
            //프리팹, 스폰 수, 스폰 간격
            Wave wave = waves[waveCount];

            GameData.Waves++;
            waveCount++;
            //Debug.Log($"{waveCount}번째 Wave");

            //이번 웨이브에서 스폰할 적의 최대 수 계산
            enemyMax = wave.count;
            enemyAlive = wave.count; // 살아있는 적의 수 초기화

            //enemyMax 만큼 적 스폰하기
            for (int i = 0; i < enemyMax; i++)
            {
                EnemySpawn(wave.prefab);
                //약간 지연, 적이 간격을 두고 스폰하도록 만든다
                yield return new WaitForSeconds(wave.delayTime);
            }
        }

        //적 스폰하기
        void EnemySpawn(GameObject prefab)
        {
            Instantiate(prefab, start.position, Quaternion.identity);
        }

        // 웨이브 대기하기
        void ReadyWave()
        {
            //버튼 활성화 체크
            if (startButton.activeSelf)
                return;

            //레벨 클리어 체크
            if (waveCount >= waves.Length)
            {
                // 레벨 클리어 로직
                Debug.Log("레벨 클리어");

                //스폰 기능 정지
                this.enabled = false;
                return;
            }

            startButton.SetActive(true);
            waveInfoUI.SetActive(false);
        }
        #endregion
    }
}