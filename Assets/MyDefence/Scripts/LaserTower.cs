using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 레어저타워를 관리하는 클래스, Tower 상속 받는다
    /// 레이저 빔 쏘기
    /// </summary>
    public class LaserTower : Tower
    {
        #region Variables
        //라인렌더러 인스턴스 - 레이저 빔
        private LineRenderer lineRenderer;

        //레이져 임펙트 파티클/라이트 인스턴스
        public ParticleSystem laserImpact;
        public Light laserLight;

        //1초당 30데미지
        [SerializeField]
        private float laserDamage = 30f;

        //이동속도 40% 감속
        [SerializeField]
        private float slowRate = 0.4f;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            lineRenderer = this.transform.GetComponent<LineRenderer>();
        }

        protected override void Update()
        {
            //0.2초마다 한번씩 공격 범위안에 있는 가장 가까운 적 찾기 
            countdown += Time.deltaTime;
            if (countdown >= searchTimer)
            {
                //타이머 실행문
                UpdateTarget();

                //타이머 초기화
                countdown = 0f;
            }

            //타겟을 못찾았으면
            if (target == null)
            {
                //레이저 빔/이펙트 을 끈다
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserImpact.Stop();
                    laserLight.enabled = false;
                }
                return;
            }

            //타겟을 찾은 다음에 if(target != null)
            //타겟(가장 가까운 Enemy)의 움직임에 따라 터렛 헤드가 타겟 방향으로 회전한다
            LockOn();

            //레이저 빔 쏘기
            ShootLaser();

        }
        #endregion

        #region Custom Method
        void ShootLaser()
        {
            //초당 30데미지 주기, 속도 줄이기
            float frameDamage = Time.deltaTime * laserDamage;   //프레임당 데미지
            //Enemy 인스턴스 가져오기
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(frameDamage);  //데미지 주기
                enemy.Slow(slowRate);           //속도 감속
            }

            //라인 렌더러 그리기 / 이펙트 - 시작시점, 엔드지점 설정
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                laserImpact.Play();
                laserLight.enabled = true;
            }

            //레이저 빔 그리기
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.transform.position);

            //레이저 타격 이펙트
            //타격 이펙트가 파이어포인트를 바라보는 방향
            Vector3 dir = firePoint.position - target.transform.position;
            laserImpact.transform.position = target.transform.position + dir.normalized / 2;
            laserImpact.transform.rotation = Quaternion.LookRotation(dir);
        }
        #endregion

    }
}