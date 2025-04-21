using UnityEngine;
using System.Collections;

namespace MyDefence
{
    //타이틀 씬을 관리하는 클래스
    public class Title : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        //다음 이동하는 씬 이름
        [SerializeField]
        private string loadToScene = "MainMenu";

        //애니키 UI 오브젝트
        public GameObject anyKey;
        
        //애니키 UI를 보여주고 있는지 체크
        private bool isShow = false;

        //타이머
        [SerializeField]
        private float titleTimer = 3f;
        private float countdown = 0f;

        [SerializeField]
        private float spawnDelay = 2f;  //생성 딜레이 2초
        private float spawTime;         //몬스터 생성한 시간 저장

        private bool isOneTime = false; //실행 안했으면 false, 한번이라도 실행 했으면 true
        #endregion

        private void Start()
        {
            //초기화
            //countdown = 0f;
            //countdown = titleTimer;
            //spawTime = Time.time;       //현재 시간 저장
            isShow = false;

            //InvokeRepeating 처음시작시 1초 딜레이후 2초간격으로 몬스터 생성
            //InvokeRepeating("SpawnMonster", 1f, 2f);

            //지연 - Invoke
            //Invoke("SpawnMonster", spawnDelay);

            //지연 - Coroutine
            //StartCoroutine(Spawn());

            StartCoroutine(titleProcess());
        }

        private void Update()
        {
            /*//Time.deltaTime 더하기 누적 반복 타이머
            countdown += Time.deltaTime;
            if(countdown >= titleTimer)
            {
                //반복 실행문
                GotoMenu();

                //타이머 초기화
                countdown = 0f;
            }*/

            /*//Time.deltaTime 빼기 누적 반복 타이머
            countdown -= Time.deltaTime;
            if(countdown <= 0f)
            {
                //반복 실행문
                GotoMenu();

                //타이머 초기화
                countdown = titleTimer;
            }*/

            /*// Time.time 현재시간을 저장하고 현재시간이 딜레이 시간 만큼 지났는지 체크
            if ((spawTime+spawnDelay) <= Time.time)
            {
                //반복 실행문
                SpawnMonster();

                //타이머 초기화 : 현재시간을 다시 저장
                spawTime = Time.time;
            }*/

            //Time.deltaTime 더하기 누적 반복 타이머 - 1회 실행
            /*if(isOneTime == false)
            {
                countdown += Time.deltaTime;
                if (countdown >= titleTimer)
                {
                    //반복 실행문
                    GotoMenu();

                    //타이머 초기화
                    countdown = 0f;
                    isOneTime = true;
                }
            }*/

            //아무 키를 누르면 메인메뉴 씬 이동로 이동
            if(Input.anyKeyDown && isShow)
            {
                //현재 대기하고 있는 모든 코루팀 함수 정지
                StopAllCoroutines();

                GotoMenu();
            }
        }

        IEnumerator titleProcess()
        {
            yield return new WaitForSeconds(titleTimer);
            ShowAnyKey();

            yield return new WaitForSeconds(10f);
            GotoMenu();
        }


        private void ShowAnyKey()
        {
            isShow = true;
            anyKey.SetActive(true);
        }

        private void GotoMenu()
        {
            //Debug.Log("Goto Menu!!!");
            //SceneManager.LoadScene(loadToScene);
            fader.FadeTo(loadToScene);
        }

        private void SpawnMonster()
        {
            Debug.Log("Spawn Monster!!!");
        }

        IEnumerator Spawn()
        {
            //spawnDelay 만큼 딜레이
            yield return new WaitForSeconds(spawnDelay);
            SpawnMonster();
        }

    }
}


/*
타이머
- 1회성 : 반복실행중 1회 실행하고 더이상 반복하지 않는다

- 반복
: 2초마다 메인메뉴 보내기
*/