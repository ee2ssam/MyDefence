using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    //필드
    float speed = 5.0f; //초속

    Vector3 targetPosition = new Vector3(7.0f, 1.5f, 8.0f);

    // Start is called before the first frame update
    void Start()
    {
        //내가 붙어있는 오브젝트의 transform 객체 접근
        //this.transform.position = new Vector3(7.0f, 1.5f, 8.0f);
        //this.transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //플레이의 위치를 앞으로 계속 이동
        //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);
        //this.transform.position += new Vector3(1f, 0f, 0f);
        //this.transform.position += Vector3.left;

        //앞 : Vector3(0f, 0f, 1f); Vector3.forward
        //뒤 : Vector3(0f, 0f, -1f); Vector3.back
        //좌 : Vector3(-1f, 0f, 0f); Vector3.left
        //우 : Vector3(1f, 0f, 0f); Vector3.right
        //위 : Vector3(0f, 1f, 0f); Vector3.up
        //아래 : Vector3(0f, -1f, 0f); Vector3.down

        //속도 - 앞 방향으로 1초에 1 unit 만큼 이동
        //transform.position += Vector3.forward * Time.deltaTime;
        //속도 - 앞 방향으로 1초에 5 unit 만큼 이동
        //transform.position += Vector3.forward * Time.deltaTime * speed;

        //Translate : transform 이동 함수
        //direction : 이동할 방향
        //Time.deltaTime 이동시 동일한 시간에 동일한 거리를 이동하게 해준다
        //speed : 속도 - 1초당 이동하는 거리
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //이동 방향 구하기
        // dir : 목표지점 - 현재지점, 목표위치 - 현재위치
        Vector3 dir = targetPosition - this.transform.position;
        //dir.normalized : 단위백터, 길이가 1인 백터, 정규환된 벡터
        //dir.magnitude : 길이, 크기
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);

        //Space.Self , Space.World
        //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self); //로컬 축 기준으로 이동
        //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World); //글로벌 축 기준으로 이동

    }
}


/*

Time.deltaTime
20프레임 : 0.05초

성능이 좋은 컴퓨터
//10프레임 - deltaTime : 0.1초
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime;  //0.1


성능이 좋은 컴퓨터
//2프레임 - deltaTime : 0.5초
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime; //0.5
transform.position += Vector3(0f, 0f, 1f) * Time.deltaTime; //0.5 















*/