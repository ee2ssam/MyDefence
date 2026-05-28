using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 회전 테스트 예제 스크립트
    /// </summary>
    public class RotateTest : MonoBehaviour
    {
        #region Variables
        //회전 속도
        public float turnSpeed = 5f;

        //이동 속도
        public float moveSpeed = 5f;

        //회전 값 변수
        private float x = 0;

        //목표 오브젝트 트랜스폼 인스턴스
        public Transform target;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f); //y축 회전하여 오른쪽 바라보기
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        private void Update()
        {
            //축 회전
            //x += 1;
            //this.transform.rotation = Quaternion.Euler(x, 0, 0); //x축
            //this.transform.rotation = Quaternion.Euler(0, x, 0); //y축
            //this.transform.rotation = Quaternion.Euler(0, 0, x); //z축

            //[1]Rotate - 자전
            //this.transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);
            //this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
            //[1-1]RotateAround - 지구의 공전
            //this.transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);

            /*//[2] 원하는(목표) 방향을 회전
            //목표 방향 구하기
            Vector3 dir = target.position - this.transform.position;
            //목표 방향에 해당되는 회전값 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            //트랜스폼의 회전값을 구한 회전값에 대입
            //this.transform.rotation = lookRotation;

            //this.transform.rotation (0,0,0) => lookRotation (0,41,0)
            //Quaternion Lerp(Quaternion a, Quaternion b, float t);
            Quaternion qRotation = Quaternion.Lerp(this.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
            //Quaternion로 부터 오일러값(x,y,z) 구하기
            Vector3 euler = qRotation.eulerAngles;
            //y축 회전하는 회전값을 구한다
            this.transform.rotation = Quaternion.Euler(0f, euler.y, 0f);*/

            //이동 dir * Time.deltaTime * speed
            Vector3 dir = target.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
            //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);

        }
        #endregion
    }
}

/*

a = 0, b = 10, t = 0.1
a = Lerp(a, b, 0.1);

a = 1, b = 10, t = 0.1
a = Lerp(a, b, 0.1);

a = 1.9, b = 10, t = 0.1
a = Lerp(a, b, 0.1);

*/