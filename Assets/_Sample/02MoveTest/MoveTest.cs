using UnityEngine;

namespace Sample
{
    public class MoveTest : MonoBehaviour
    {
        //이동 목표 지점 변수 선언 및 초기화
        private Vector3 targetPosition = new Vector3(7f, 1f, 8f);

        //이동 목표 위치에 있는 오브젝트의 트랜스폼 인스턴스
        public Transform target;

        //이동 속도를 저장하는 변수를 선언하고 초기화
        public float speed = 5f;       //1초에 가는 거리


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //this.gameObject.transform
            //this.transform.gameObject
            //this.transform.position = new Vector3(7f, 1f, 8f);
            //Debug.Log(this.transform.position);

            //this.transform.position = targetPosition;

            //Debug.Log(target.position);
            //this.transform.position = target.position;
        }

        // Update is called once per frame
        void Update()
        {
            //플레이어의 위치를 앞으로 이동 : z축 값이 증가한다
            //this.transform.position 연산으로 구현 - Vector3 을 이용
            //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);
            //
            //this.transform.position += Vector3.forward;

            //앞, 뒤, 좌, 우, 위, 아래 이동
            //Vector3(0f, 0f, 1f); Vector3.forward
            //Vector3(0f, 0f, -1f); Vector3.back
            //Vector3(-1f, 0f, 0f); Vector3.left
            //Vector3(1f, 0f, 0f); Vector3.right
            //Vector3(0f, 1f, 0f); Vector3.up
            //Vector3(0f, -1f, 0f); Vector3.down

            //Vector3(1f, 1f, 1f);  Vector3.one - 단위백터
            //Vector3(0f, -0f, 0f); Vector3.zero

            //앞 방향으로 1초에 1unit 만큼씩 이동하라
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
            //this.transform.position += Vector3.forward * Time.deltaTime;

            //앞 방향으로 1초에 5 만큼씩 이동하라
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;

            //Translate
            //dir(방향) : 이동할 방향 지정
            //Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다
            //speed : 이동의 빠르기 지정
            // dir * Time.deltaTime * speed => 연산의 결과는 Vector3
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);

            //이동 방향 구하기 : (목표지점 - 현재지점) (도착위치 - 현재위치)
            //dir.normalized : 단위백터, 길이가 1인 백터, 정규화된 백터
            //dir.magnitude : 백터의 길이, 크기
            //Vector3 dir = target.position - this.transform.position;
            //this.transform.Translate(dir.normalized * Time.deltaTime * speed);
            //this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);

            //Space.Self, Space.World
            //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        }
    }
}

/*
n프레임 : 1초당 n번 실행
20프레임

this.transform.position += new Vector3(0f, 0f, 1f);

Time.deltaTime : 한 프레임 돌아오는데 걸리는 시간

성능 좋은 컴
10프레임 - 1초에 10unit 이동 (Time.deltaTime을 고려하지 않았을때)

Time.deltaTime : 0.1초
10프레임 - 1초에 1unit 이동 (Time.deltaTime을 고려)

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


성능 나쁜 컴
2프레임 - 1초에 2unit 이동 (Time.deltaTime을 고려하지 않았을때)

Time.deltaTime : 0.5초 
2프레임 - 1초에 1unit 이동 (Time.deltaTime을 고려)

this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.5씩 증가
this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime; //0.5씩 증가


*/
