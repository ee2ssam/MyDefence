using UnityEngine;
using UnityEngine.Windows;

namespace Sample
{
    public class MoveRb : MonoBehaviour
    {
        private Rigidbody rb;
        public float moveSpeed = 1.0f;
        public float force = 3.0f;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();

            //힘으로 이동
            //rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            //if (조건)
            {
                rb.AddForce(Vector3.forward * force, ForceMode.Force);
            }

            //kinematic move
            //rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }
}


/*
3D 충돌체 (충돌 오브젝트)
정적 충돌체 : 움직이지 않는 충돌체
- Static : 벽, 건물, 큰 바위, 
동적 충돌체 : 움직이는 충돌체 - Rigidbody (오브젝트의 움직임을 물리력으로 제어)
- Kinetic : 외부에서 오는 물리력 무시, 운동학, 이동하는 발판, 문
- Dynamic : 그외 물리력으로 제외되는 오브젝트

충돌체크
: 두 오브젝트가 모두 충돌체를 가지고 있어야 한다
: 그중의 하나는 Rigidbody(Dynamic) 이어야 하고 Rigidbody(Dynamic)이 이동하는 오브젝트 이어야 한다
: 이동하는 Kinetic은 Dynamic과 충돌체크 된다


2D 충돌체 (충돌 오브젝트)
정적 충돌체 : 움직이지 않는 충돌체
- Static : 벽, 건물, 큰 바위, 
동적 충돌체 : 움직이는 충돌체 - Rigidbody (오브젝트의 움직임을 물리력으로 제어)
- Static :
- Kinetic : 외부에서 오는 물리력 무시, 운동학, 이동하는 발판, 문
- Dynamic : 그외 물리력으로 제외되는 오브젝트

충돌체크
: 두 오브젝트가 모두 충돌체를 가지고 있어야 한다
: 그중의 하나는 Rigidbody(Dynamic) 이어야 하고(o) Rigidbody(Dynamic)이 이동하는 오브젝트 이어야 한다 (x)
: 이동하는 Kinetic은 Dynamic과 충돌체크 된다

//
AddForce : ForceMode 4가지
ForceMode.Force (연속, 질량 고려)
- 바람, 자기력 처럼 연속적으로 힘을 주는것
- 짧은 시간에 발생하는 힘

ForceMode.Acceleration (연속, 질량 무시)
- 지구의 중력
- 질량에 상관없이 일정한 가속량을 주는 힘

ForceMode.Impulse (불연속, 질량 고려)
- 폭발, 타격
- 순간적으로 작용하는 힘

ForceMode.VelocityChange (불연속, 질량 무시)
- 질량을 무시하고 직접적으로 속도의 변화를 주는 힘
*/
