using UnityEngine;

namespace Sample
{
    //타겟으로 이동한다
    public class PlayerMoveTest : MonoBehaviour
    {
        #region Field
        //이동 속도
        public float moveSpeed = 5f;

        //타겟이으로 이동하기위해서는 타겟 오브젝트의 transform 정보가 필요
        public Transform target;
        public GameObject targetGo;

        //타겟 오브젝트에 붙어 있는 TargetTest 컴포넌트(스크립트)의 객체를 GetComponent로 가져오기
        //private TargetTest targetTest;

        //타겟 오브젝트에 붙어 있는 TargetTest 컴포넌트(스크립트)의 객체를 public으로 가져오기
        public TargetTest targetTest;

        //자신 오브젝트에 붙어 있는 MyTest 컴포넌트(스크립트)의 객체를 GetComponent로 가져오기
        private MyTest myTest;
        //public MyTest myTest;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            //targetTest = target.GetComponent<TargetTest>();
            //targetTest.SetA(60);
            //Debug.Log($"targetTest.a:{targetTest.GetA()}");
            //targetTest.b = 30;
            //Debug.Log($"targetTest.b:{targetTest.b}");

            //myTest = this.transform.GetComponent<MyTest>();
            myTest = this.GetComponent<MyTest>();            

            myTest.SetA(60);
            Debug.Log($"myTest.a:{myTest.GetA()}");
            myTest.b = 30;
            Debug.Log($"myTest.b:{myTest.b}");

            //초기화

        }

        // Update is called once per frame
        void Update()
        {
            //이동
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        }
    }
}

/*





*/