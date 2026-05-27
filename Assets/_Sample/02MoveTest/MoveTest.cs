using UnityEngine;

namespace MySample
{
    //게임오브젝트의 이동
    public class MoveTest : MonoBehaviour
    {
        //이동 목표지점 변수 선언 및 초기화
        private Vector3 targetPosition = new Vector3(7f, 1f, 8f);

        //이동 목표 위치에 있는 오브젝트의 트랜스폼 인스턴스 선언
        public Transform target;

        //이동 속도를 저장하는 변수를 선언하고 초기화
        public float speed = 10f;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //this.gameObject, gamObject : MoveTest 스크립트가 붙어있는 게임오브젝트의 객체(인스턴스)
            //this.gameObject.transform, gameObject.transform,
            //      : MoveTest 스크립트가 붙어있는 게임오브젝트의 트랜스폼의 객체(인스턴스)
            // this.transform, transform
            //this.transform.position = new Vector3(7f, 1f, 8f);
            //this.gameObject.transform.position = new Vector3(7f, 1f, 8f);

            //this.transform.position = targetPosition;

            //Debug.Log($"타겟 위치:{target.position}");
            //this.transform.position = target.position;
        }

        // Update is called once per frame
        void Update()
        {
            //플레이어의 위치를 앞으로 이동: z축 값이 증가한다
            //this.transform.position z축 값 증가: Vector3 연산
            //this.transform.position.z = this.transform.position.z + 1.0f; error
            //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);

            //앞,뒤,좌,우,위,아래
            //this.transform.position += Vector3.forward;   //Vector3(0f, 0f, 1f);
            //this.transform.position += Vector3.back;      //Vector3(0f, 0f, -1f);
            //this.transform.position += Vector3.left;      //Vector3(-1f, 0f, 0f);
            //this.transform.position += Vector3.right;     //Vector3(1f, 0f, 0f);
            //this.transform.position += Vector3.up;        //Vector3(0f, 1f, 0f);
            //this.transform.position += Vector3.down;        //Vector3(0f, -1f, 0f);

            //Vector3.one : Vector3(1f, 1f, 1f); - 단위백터
            //Vector3.zero : Vector3(0f, 0f, 0f); - 초기값

            //앞방향으로 1초에 1unit 만큼씩 이동            
            //this.transform.position += Vector3.forward * Time.deltaTime;

            //앞방향으로 1초에 speed(속도값) 만큼씩 이동
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;
            //this.transform.position += Vector3.forward * Time.deltaTime * speed;

            //이동 요소
            //방향: 이동할 방향 지정
            //Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다
            //속도(speed) : 이동의 빠르기 지정

            //Translate
            //this.transform.Translate(Vector3.forward * Time.deltaTime * speed);

            //타겟까지 이동에 필요한 요소 3가지 (dir(방향), Time.deltaTime, speed)
            //dir.normalized : dir방향으로 크기 1인 백터, 단위백터, 정규화된 백터 
            //dir.magnitude : dir의 크기, 백터의 크기, 길이
            //이동 방향 구하기 : 목표지점 - 현재지점, 도착 예정위치 - 출발(현재) 위치
            Vector3 dir = target.position - this.transform.position;
            //this.transform.Translate(dir.normalized * Time.deltaTime * speed);
            //this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);
            this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

            //Space.Self, Space.World
            //this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            //this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

        }
    }
}


/*
n 프레임: 초당 n번 실행(보여주기)
20 프레임 : 초당 20번 실행 
20프레임이면 1 프레임당 걸리는 시간? : 0.05초

Time.deltaTime : 실제 한프레임에 걸리는 시간을 저장한 변수

성능이 좋은 컴(PC1)
10 프레임
- Time.deltaTime을 고려하지 않을 경우 1초에 10만큼이동
- Time.deltaTime을 고려하는 경우 ( * Time.deltaTime) : 1초에 1만큼 이동
Time.deltaTime : 0.1f

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.1씩 증가


성능이 나쁜 컴(PC2)
2 프레임
- Time.deltaTime을 고려하지 않을 경우 1초에 2만큼이동
- Time.deltaTime을 고려하는 경우 (* Time.deltaTime) : 1초에 1만큼 이동
Time.deltaTime : 0.5f

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.5씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.5씩 증가


*/