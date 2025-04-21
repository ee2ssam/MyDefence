using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefence
{
    //Enemy 스폰/웨이브를 관리하는 스크립트
    public class WaveManager : MonoBehaviour
    {
        #region Field
        //현재 게임 화면에서 살아있는 enemy 숫자
        public static int enemyAlive = 0;

        //웨이브 데이터 셋팅 : 적 프리팹, 생성할 갯수
        public Wave[] waves;

        //적 프리팹
        public GameObject enemyPrefab;

        //적 스폰위치
        public Transform startPoint;

        //타이머
        public float waveTimer = 5f;
        private float countdown = 0f;

        //웨이브 카운트
        private int waveCount = 0;

        //UI Countdown Text
        public TextMeshProUGUI countdownText;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            countdown = 3f;
            waveCount = 0;
            enemyAlive = 0;
        }

        // Update is called once per frame
        void Update()
        {
            //현재 맵에 enemy가 있는지 여부 체크: 스폰, 카운트 다운 막는다
            if (enemyAlive > 0)
            {
                return;
            }   

            //타이머 구현
            countdown += Time.deltaTime;
            if(countdown >= waveTimer)
            {
                //타이머 기능
                StartCoroutine(SpawnWave());

                //타이머 초기화
                countdown = 0f;
            }

            //UI
            countdownText.text = Mathf.Round(countdown).ToString();
        }

        //웨이브
        IEnumerator SpawnWave()
        {
            waveCount++;

            //라운드 카운트
            PlayerStats.Rounds++;
            
            for (int i = 0; i < waveCount; i++)
            {
                SpawnEnemy();

                //일정시간 지연
                yield return new WaitForSeconds(0.5f);
            }
        }

        //시작 지점에 enemy 스폰
        void SpawnEnemy()
        {
            enemyAlive++;
            Debug.Log($"enemyAlive 생성: {WaveManager.enemyAlive}");

            Instantiate(enemyPrefab, startPoint.position, Quaternion.identity);
        }
    }
}