using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class MapTileGenerater : MonoBehaviour
    {
        //필드
        //맵타일 프리팹
        public GameObject tilePrefab;

        //생성되는 맵타일들의 부모 오브젝트
        //public Transform parent;

        //맵타일 생성 여부 확인
        private bool isCreate = false;


        // Start is called before the first frame update
        void Start()
        {
            //[1] 특정한 위치에 생성하기
            //Instantiate(tilePrefab, new Vector3(5f, 0f, 8f), Quaternion.identity);
            //Vector3 position = new Vector3(5f, 0f, 8f);
            //Instantiate(tilePrefab, position, Quaternion.identity);

            //GameObject go = Instantiate(tilePrefab);
            //go.transform.position = new Vector3(5f, 0f, 8f);

            //[2] 10x10 맵 타일 생성하기
            //CreateMapTile();

            //[3] 6x8 맵 타일 생성하기 7x5
            //CreateMapTile(7, 5);

            //[4] 랜덤위치에 맵타일 10개 생성하기
            //GenerateRandomMapTile(10);


            //[5] 1초후에 맵타일을 특정한 위치에 생성하기
            //Debug.Log("[1]스타트코루틴 함수 호출");
            //StartCoroutine(GenerateMapTile());
            //Debug.Log("[9]스타트코루틴 함수 다음 실행 명령");

            //[6] 10x10 맵 타일 생성하는데 타일 하나씩 찍기
            //하나 찍고 0.1초 지연후 다음 타일 찍기
            //StartCoroutine(GenearateMapTile2());
        }

        // Update is called once per frame
        void Update()
        {
            if(isCreate == false)
            {
                Debug.Log("[1]스타트코루틴 함수 호출");
                StartCoroutine(GenearateMapTile2());

                Debug.Log("[9]스타트코루틴 함수 호출 완료");
                isCreate = true;
            }
            
        }

        IEnumerator GenerateMapTile()
        {
            Debug.Log("[2]코루틴 함수 시작");
            //2초 지연
            yield return new WaitForSeconds(2f);

            Debug.Log("[3]2초 지연후 맵타일 생성");
            Vector3 position = new Vector3(5f, 0f, 8f);
            Instantiate(tilePrefab, position, Quaternion.identity);

            //2초 지연
            yield return new WaitForSeconds(2f);

            Debug.Log("[4]2초 지연후 맵타일 생성");
            position = new Vector3(8f, 0f, 5f);
            Instantiate(tilePrefab, position, Quaternion.identity);

            Debug.Log("[5]코루틴 함수 종료");
        }

        IEnumerator GenearateMapTile2()
        {
            Debug.Log("[2]코루틴 함수 시작");

            Debug.Log("[3]맵타일 찍기 시작");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector3 position = new Vector3(i * 2.0f, 0f, -j * 2.0f);
                    Instantiate(tilePrefab, position, Quaternion.identity, this.transform);

                    Debug.Log("[4]0.1초 지연");
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }


        //10x10 맵 제네레이터 만들기
        void CreateMapTile()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector3 position = new Vector3(i * 2.0f, 0f, -j * 2.0f);
                    Instantiate(tilePrefab, position, Quaternion.identity);
                }
            }
        }

        // row x column 맵 제네레이터 만들기 - 78
        void CreateMapTile(int row, int column)
        {
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Vector3 position = new Vector3(i * 2.0f, 0f, -j * 2.0f);
                    //Instantiate(tilePrefab, position, Quaternion.identity);
                    //Instantiate(tilePrefab, position, Quaternion.identity, parent);
                    //Instantiate(tilePrefab, position, Quaternion.identity, this.transform);

                    //GameObject go = Instantiate(tilePrefab);
                    GameObject go = Instantiate(tilePrefab, this.transform);
                    go.transform.position = position;
                }
            }
        }

        void GenerateRandomMapTile(int n)
        {
            int i = 0, j = 0;

            for(int k = 0 ;k < n ;k++)
            {
                i = Random.Range(0, 10);
                j = Random.Range(0, 10);
                Vector3 position = new Vector3(i * 2.0f, 0f, -j * 2.0f);

                Instantiate(tilePrefab, position, Quaternion.identity, this.transform);
            }
        }
    }
}