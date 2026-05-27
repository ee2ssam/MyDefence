using UnityEngine;
using System.Collections;

namespace MySample
{
    public class PrefabTest : MonoBehaviour
    {
        #region Variables
        //생성할 프리팹 게임 오브젝트 원본 가져오기
        public GameObject prefab;

        //타이머 변수 선언 - 2개
        public float tileTimer = 1f;    //타이머 기준 시간
        private float countdown = 0f;   //시간(Time.deltaTime) 누적 변수
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //[1] 프리팹 게임오브젝트의 사본 만들기
            //Instantiate(prefab);

            //[2] 지정된 위치(5, 0.05, 8)에 프리팹 게임오브젝트의 사본 만들기
            //Instantiate(prefab, new Vector3(5.0f, 0.05f, 8f), Quaternion.identity);
            //Vector3 position = new Vector3(5f, 0.05f, 8f);
            //Instantiate(prefab, position, Quaternion.identity);
            //사본의 GameObject 객체(인스턴스) 반환
            //GameObject go = Instantiate(prefab);
            //go.transform.position = new Vector3(5f, 0.05f, 8f);

            //[3] 맵타일 찍기 (가로(10) x 세로(10), 타일간 간격은 5)
            //GenerateMapTile(10, 10);
            //GenerateMapTile(10, 10, this.transform); //부모 지정

            //[4] 랜덤위치에 타일 10개 찍기
            /*for (int i = 0; i < 10; i++)
            {
                GenerateRandomMapTile();
            }*/

            //[5]
            //타이머 초기화
            //countdown = tileTimer;

            //[6] 랜덤위치에 타일을 1초마다 1개씩 찍기 - 모두 10개 찍기
            //타일1개 찍고 -> 1초 딜레이 -> 타일1개 찍고 ->1초 딜레이
            //코루틴 함수 호출 : StartCoroutine(코루틴 함수이름())
            Debug.Log("[0] 코루틴 함수 시작");
            StartCoroutine(CreateMapTile());
            Debug.Log("[4] 타일 생성 완료");

        }

        private void Update()
        {
            //[5] 랜덤위치에 타일을 1초마다 1개씩 찍기
            /*countdown += Time.deltaTime;
            if(countdown >= tileTimer)
            {
                //타이머 기능 샐행 - 타일찍기
                GenerateRandomMapTile();

                //타이머 초기화
                countdown = 0f;
            }*/
            
            /*if (countdown <= 0f)
            {
                //타이머 기능 샐행 - 타일찍기
                GenerateRandomMapTile();

                //타이머 초기화
                countdown = tileTimer;
            }
            countdown -= Time.deltaTime;*/


        }
        #endregion

        #region Custom Method
        //코루틴 함수 정의 - 맵타일 찍기
        IEnumerator CreateMapTile()
        {
            /*//랜덤타일 찍기
            GenerateRandomMapTile();
            Debug.Log("[1] 첫번째 타일 생성");
            //1초 지연
            yield return new WaitForSeconds(1.0f);

            //랜덤타일 찍기
            GenerateRandomMapTile();
            Debug.Log("[2] 두번째 타일 생성");
            //1초 지연
            yield return new WaitForSeconds(1.0f);

            //랜덤타일 찍기
            GenerateRandomMapTile();
            Debug.Log("[3] 세번째 타일 생성");
            //1초 지연
            yield return new WaitForSeconds(1.0f);*/

            for (int i = 0; i < 10; i++)
            {
                GenerateRandomMapTile();
                Debug.Log($"{i+1}번째 세번째 타일 생성");
                yield return new WaitForSeconds(1.0f);
            }
        }

        //매개변수로 가로, 세로 타일 갯수을 입력받아 맵타일 찍는 함수
        void GenerateMapTile(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    //생성하면서 위치, 방향 지정
                    //Vector3 position = new Vector3(j * 5f, 0.05f, i * -5f);
                    //Instantiate(prefab, position, Quaternion.identity);

                    //생성 후 위치 지정
                    GameObject go = Instantiate(prefab);
                    go.transform.position = new Vector3(j * 5f, 0.05f, i * -5f);
                }
            }
        }

        //매개변수로 생성되는 맵타일의 부모오브젝트, 가로, 세로 타일 갯수을 입력받아 맵타일 찍는 함수
        void GenerateMapTile(int row, int column, Transform parent)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //생성하면서 위치, 방향 지정
                    //Vector3 position = new Vector3(j * 5f, 0.05f, i * -5f);
                    //Instantiate(prefab, position, Quaternion.identity, parent);

                    //생성 후 위치 지정
                    GameObject go = Instantiate(prefab, parent);
                    go.transform.position = new Vector3(j * 5f, 0.05f, i * -5f);
                }
            }
        }

        //10x10 맵타일 중 랜덤한 타일 하나 찍기
        void GenerateRandomMapTile()
        {
            int randRow = Random.Range(0, 10);
            int randColumn = Random.Range(0, 10);

            Vector3 position = new Vector3(randColumn * 5f, 0.05f, randRow * -5f);
            Instantiate(prefab, position, Quaternion.identity);
        }
        #endregion

    }
}

/*



*/