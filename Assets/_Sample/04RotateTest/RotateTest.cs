using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        #region Variablse
        //축 회전 누적 값을 저장하는 변수
        float x = 0f;

        //회전 속도
        public float rotateSpeed = 10f;

        //이동 속도
        public float moveSpeed = 5f;

        //타겟
        public Transform target;
        #endregion

        #region Unity Event Method
        void Start()
        {
            //회전값 설정
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        private void Update()
        {
            //x축, y축, z축으로 회전 구현
            //x += 1;
            //this.transform.rotation = Quaternion.Euler(x, 0, 0);  //x축
            //this.transform.rotation = Quaternion.Euler(0, x, 0);  //y축
            //this.transform.rotation = Quaternion.Euler(0, 0, x);  //z축

            //[1] Rotate (자전)
            //this.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
            //[1-2] RotateAround (타겟 기준으로 공전)
            //this.transform.RotateAround(target.position, Vector3.up, Time.deltaTime * 20f);

            /*//타겟을 향해 회전
            //타겟을 향한 방향을 구한다 : 타겟위치 - 현재위치
            Vector3 dir = target.position - this.transform.position;

            //타겟 방향에 대한 회전값 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);

            //회전값(x,y,z,w)에서 euler값(x,y,z) 얻어오기
            Vector3 eulerValue = lerpRotation.eulerAngles;
            //euler값(x,y,z)에서 회전값(x,y,z,w) 얻어오기 - y축 값만 회전에 적용
            this.transform.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);*/

            //타겟을 향해 회전과 이동
            Vector3 dir = target.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(dir);

            //this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.Self);
            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

        }
        #endregion
    }
}