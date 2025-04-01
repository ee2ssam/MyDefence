using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        //필드
        private float x;
        //회전속도
        public float turnSpeed = 5f;
        //이동속도
        public float moveSpeed = 5f;

        //타겟 오브젝트
        public Transform target;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);    //x축 회전
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);    //y축 회전
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);    //z축 회전
        }

        // Update is called once per frame
        void Update()
        {
            //x += 1;
            //y축 기준으로 +회전하기
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f);
            //x축 기준으로 +회전하기
            //this.transform.rotation = Quaternion.Euler(x, 0f, 0f);
            //z축 기준으로 +회전하기
            //this.transform.rotation = Quaternion.Euler(0f, 0f, x);

            //y축 기준으로 속도 5로 회전하기
            //x += Time.deltaTime * 5;
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f);

            //y축 기준으로 속도 5로 회전하기 - 자전
            //this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
            //타겟 오브젝트 중심으로 회전하기 - 공전
            //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);

            //타겟 방향으로 회전하기
            //Vector3 dir = target.position - this.transform.position;
            //방향 벡터로 부터 그쪽 방향을 바라보는 회전값 구하기
            //Quaternion targetRotation = Quaternion.LookRotation(dir);
            //transform.rotation = targetRotation;
            //Quaternion lookRotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
            //Y축 연산을 위해 Euler(오일러)값 얻어오기
            //Vector3 eulerRotation = lookRotation.eulerAngles; //eulerRotation.x, eulerRotation.y, eulerRotation.z
            //Euler(오일러)값 으로 Quaternion(쿼터니언) 값 구하기
            //this.transform.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);

            //회전 + 이동
            //타겟 방향 구하기
            Vector3 dir = target.position - this.transform.position;
            //방향 벡터를 바라보는 회전값 적용하기
            this.transform.rotation = Quaternion.LookRotation(dir);
            //this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
            //this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.Self);
        }
    }
}


/*
Quaternion(쿼터니언)
Euler(오일러)

[1] Euler(오일러)값에서 Quaternion(쿼터니언) 값 구하기
3자리에서 4자리값 구하기
Quaternion(쿼터니언) 값 = Quaternion.Euler(Euler x, Euler y, Euler z)

[2] Quaternion(쿼터니언) 값에서 Euler(오일러)값 구하기
4자리에서 3자리값 구하기
Vector3 angles = Quaternion(transform.rotation).eulerAngles;
*/
