using MyDefence;
using UnityEngine;

namespace Sample
{
    /// <summary>
    /// wasd 키 누르면 앞뒤좌우 이동, F키 누르면 뷸렛 발사 구현
    /// </summary>
    public class PlayerMoveTest : MonoBehaviour
    {
        #region Variables
        public float speed = 5f;

        //총알 프리팹 오브젝트
        public GameObject bulletPrefab;
        public Transform firePoint;

        public GameObject target;

        //공격 범위
        public float attackRange = 7f;

        //찾기 타이머
        public float searchTimer = 0.2f;
        protected float countdown = 0f;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //0.2초마다 (가장 가까운 적 찾기)
            if (countdown <= 0f)
            {
                //타이머 기능 - 가장 가까운 적 찾기
                UpdateTarget();

                //타이머 초기화
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;


            //이동
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 dir = Vector3.right * moveX + Vector3.forward * moveY;
            transform.Translate(dir * Time.deltaTime * speed, Space.World);


            //타겟을 아직 못찾았으면
            if (target == null)
                return;

            //회전
            //Vector3 dirRotate = target.transform.position - transform.position;
            //transform.rotation = Quaternion.LookRotation(dirRotate);
            transform.LookAt(target.transform);

            //발사 버튼
            if(Input.GetKeyDown(KeyCode.F))
            {
                Fire();
            }
        }
        #endregion

        #region Custom Method
        //타워에서 가장 가까운 적 찾기
        protected void UpdateTarget()
        {
            //맵 위에 있는 모든 enemy 게임오브젝트 가졍오기
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //최소거리 변수 초기화
            float minDistance = float.MaxValue;
            //최소거리에 있는 게임오브젝트 변수
            GameObject nearEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                //enemy과의 거리 구하기
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            //가장 가까운 적을 찾았다, 이때 최소거리는 공격 범위보다 작어야 한다
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
            }
            else
            {
                target = null;
            }
        }

        private void Fire()
        {
            //Debug.Log("발사!!!");
            //총구(Fire Point) 위치에 탄환 객체 생성(Instiate)하기
            GameObject bullotGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            BulletTest bullet = bullotGo.GetComponent<BulletTest>();
            if (bullet != null)
            {
                bullet.SetTarget(target.transform);
            }

            //일정시간 지나면 자동으로 킬
            Destroy(bullotGo, 3f);
        }
        #endregion
    }
}