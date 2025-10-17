using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Variables
        //공격 타겟이 된 Enemy - 가장 가까운 적
        protected GameObject target;

        //회전
        public Transform partToRotate;  //회전을 관리하는 오브젝트
        public float rotateSpeed = 10f; //회전 속도

        //공격 범위
        public float attackRange = 7f;

        //찾기 타이머
        public float searchTimer = 0.2f;
        protected float countdown = 0f;

        //발사 타이머
        public float fireTimer = 1f;
        private float fireCountdown = 0f;

        //총알 프리팹 오브젝트
        public GameObject bulletPrefab;
        public Transform firePoint;


        #endregion

        #region Unity Event Method
        protected virtual void Start()
        {
            //초기화
            countdown = searchTimer;
        }

        protected virtual void Update()
        {
            //0.2초마다 (가장 가까운 적 찾기)
            if(countdown <= 0f)
            {
                //타이머 기능 - 가장 가까운 적 찾기
                UpdateTarget();

                //타이머 초기화
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;

            //타겟을 아직 못찾았으면
            if (target == null)
                return;

            //타겟을 향해서 partToRotate 회전
            LockOn();

            //가장 가까운 적(target)에게 1초마다 총알을 발사
            fireCountdown += Time.deltaTime;
            if(fireCountdown >= fireTimer)
            {
                //타이머 기능
                Shoot();                

                //타이머 초기화
                fireCountdown = 0f;
            }
        }

        private void OnDrawGizmosSelected()
        {
            //타워중심에 attackRange 범위 확인
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
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
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            //가장 가까운 적을 찾았다, 이때 최소거리는 공격 범위보다 작어야 한다
            if(nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
            }
            else
            {
                target = null;
            }
        }

        //타겟을 향해 터렛 헤드 돌리기
        protected void LockOn()
        {
            //방향을 구하기
            Vector3 dir = target.transform.position - this.transform.position;
            //방향에 회전값을 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Quaternion lerpRotation =
                Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed);
            Vector3 eulerValue = lerpRotation.eulerAngles;
            //Y축으로만 회전하기
            partToRotate.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);
        }

        //발사
        void Shoot()
        {
            //Debug.Log("발사!!!");
            //총구(Fire Point) 위치에 탄환 객체 생성(Instiate)하기
            GameObject bullotGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Bullet bullet = bullotGo.GetComponent<Bullet>();
            if(bullet != null)
            {
                bullet.SetTarget(target.transform);
            }
            //일정시간 지나면 자동으로 킬
            //Destroy(bullotGo, 3f);
        }
        #endregion

    }
}
