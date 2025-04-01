using UnityEngine;

namespace MyDefence
{
    //MachineGunTower를 관리하는 클래스
    public class MachineGunTower : MonoBehaviour
    {
        #region Field
        //공격 범위
        public float attackRange = 7f;

        //가장 가까운 적
        private Transform target;

        //Enemy tag
        public string enemyTag = "Enemy";

        //search 타이머
        public float searchTimer = 0.5f;
        private float countdown = 0f;

        //터렛 헤드 회전
        public Transform partToRotate;
        public float turnSpeed = 5f;

        //shoot 타이머 - 1초에 한발씩 발사
        public float shootTimer = 1f;
        private float shootCountdown = 0;

        //Bullet 발사
        //뷸렛 프리팹
        public GameObject bulletPrefab;
        //발사 위치
        public Transform firePoint;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //UpdateTarget 함수를 즉시 0.5초 마다 반복해서 호출한다
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        //가장 가까운 적 찾기
        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            //최소 거리 일때의 적 구하기
            float minDistance = float.MaxValue;
            GameObject nearEnemy = null;

            foreach (var enemy in enemies)
            {
                float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            //Debug.Log($"minDistance: {minDistance}");
            if(nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy.transform;                
            }
            else
            {
                target = null;
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            //가장 가까운 적 찾기
            /*countdown += Time.deltaTime;
            if(countdown >= searchTimer)
            {
                //타이머 기능(함수) 호출
                UpdateTarget();

                //타어미 초기화
                countdown = 0f;
            }*/

            //타겟이 없으면
            if (target == null)
                return;

            //타겟 조준
            LockOn();

            //타겟팅이 되면 터렛이 1초마다 1발씩 쏘기            
            shootCountdown += Time.deltaTime;
            if(shootCountdown >= shootTimer)
            {
                //타이머 기능 - 1발씩 쏘기
                Shoot();                

                //타이머 초기화
                shootCountdown = 0f;
            }

        }

        //탄환 발사
        private void Shoot()
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Bullet bullet = bulletGo.GetComponent<Bullet>();
            if(bullet != null)
            {
                bullet.SetTarget(target);
            }
        }

        //타겟 조준
        void LockOn()
        {
            //터렛 헤드 회전
            Vector3 dir = target.position - this.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            Quaternion lookRoatation = Quaternion.Lerp(partToRotate.rotation, targetRotation, Time.deltaTime * turnSpeed);
            Vector3 eulerRotation = lookRoatation.eulerAngles;  //4자리에 3자리 구하기
            partToRotate.rotation = Quaternion.Euler(0f, eulerRotation.y, 0f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }
    }
}