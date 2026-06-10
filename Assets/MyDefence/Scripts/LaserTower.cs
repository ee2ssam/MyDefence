using UnityEngine;

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
                //레이저 빔을 끈다
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
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
            //라인 렌더러 그리기 - 시작시점, 엔드지점 설정
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.transform.position);
        }
        #endregion

    }
}