using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Variables
        //타워 공격
        private GameObject target;      //공격 범위안에 있는 가장 가까운 적
        public float attackRange = 7f;  //타워 공격 범위

        //타워 회전
        public Transform partToRotate;  //타워의 회전을 관리하는 오브젝트
        public float turnSpeed = 10f;

        //SearchTimer 0.2초
        public float searchTimer = 0.2f;
        private float countdown = 0f;

        //발사 타이머 1초에 한발씩
        public float fireTimer = 1.0f;
        private float fireCountdown = 0f;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //0.2초마다 한번씩 공격 범위안에 있는 가장 가까운 적 찾기 
            countdown += Time.deltaTime;
            if(countdown >= searchTimer)
            {
                //타이머 실행문
                UpdateTarget();

                //타이머 초기화
                countdown = 0f;
            }

            //타겟을 못찾았으면
            if (target == null)
                return;

            //타겟을 찾은 다음에 if(target != null)
            //타겟(가장 가까운 Enemy)의 움직임에 따라 터렛 헤드가 타겟 방향으로 회전한다
            LockOn();

            //타겟팅이 되면 터렛이 1초마다 1발씩 쏘기
            fireCountdown += Time.deltaTime;
            if( fireCountdown >= fireTimer )
            {
                //타이머 실행문 - 총알 발사
                Debug.Log("Shooot!!!");

                //타이머 초기화
                fireCountdown = 0f;
            }
        }

        //해당(this, 스크립트가 붙어있는) 오브젝트를 선택했을때만 기즈모를 그린다
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            //타워를 중심으로 반경이 7인 구를 그린다
            //Gizmos.DrawSphere(this.transform.position, attackRange);
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }

        /*//항상 기즈모를 그린다
        private void OnDrawGizmos()
        {
            
        }*/
        #endregion

        #region Custom Method
        //3. 터렛에서 가장 가까운 적 찾아(Tag "Enemy")  타겟으로 설정
        void UpdateTarget()
        {
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject closest = null;              //가장 가까운 enemy
            float minDistance = Mathf.Infinity;     //최소 거리

            foreach (GameObject enemy in enemies)
            {
                //적과의 거리 구하기
                float distance = Vector3.Distance(enemy.transform.position, this.transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance; 
                    closest = enemy;        //최소 거리에 해당되는 적
                }
            }

            //closest 검증
            if(closest != null && minDistance <= attackRange)
            {
                target = closest;
            }
            else
            {
                target = null;
            }
        }

        //타겟(가장 가까운 Enemy)의 움직임에 따라 터렛 헤드가 타겟 방향으로 회전한다
        void LockOn()
        {
            Vector3 dir = target.transform.position - partToRotate.position;
            //목표 방향에 해당되는 회전값 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            partToRotate.rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }
        #endregion
    }
}