using UnityEngine;

namespace Sample
{
    public class PlayerMoveTest : MonoBehaviour
    {
        #region Variables
        //이동
        public Transform target;
        public float moveSpeed = 5f;

        //탄환발사
        public GameObject bulletPrefab;
        public Transform firePoint;
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {            
            //스페이스 키를 누르면 탄환 발사
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }

            //이동
            Move();
        }

        void Fire()
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            BulletTest bulletTest = bulletGo.GetComponent<BulletTest>();
            if(bulletTest != null )
            {
                bulletTest.MoveByForce();
            }
            Destroy(bulletGo, 3f);
        }

        void Move()
        {
            //wasd 입력을 받아 이동 구현
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(transform.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-transform.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-transform.right * Time.deltaTime * moveSpeed, Space.World);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.right * Time.deltaTime * moveSpeed, Space.World);
            }

            //항상 타겟을 바라보도록 구현(총구를 자동으로 타겟팅)
            Vector3 dir = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}