using UnityEngine;

namespace MyDefence
{
    //레이저 타워를 관리하는 클래스
    public class LaserTower : Tower
    {
        #region Field
        public LineRenderer lineRenderer;   //레이저빔 그리기
        public ParticleSystem impactEffect; //레이저 임팩트 효과
        public Light impactLight;

        //초당 30데미지 주기
        [SerializeField] private float laserDamage = 30f;
        //속도 40% 감속
        [SerializeField] private float slowRate = 0.4f;
        #endregion


        protected override void Update()
        {
            //타겟이 없으면
            if (target == null)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
                return;
            }

            //타겟 조준
            LockOn();

            //레이저 빔 그리기
            Laser();
        }

        void Laser()
        {
            //레이저 효과 연산하기            
            //이번 프레임에 주는 데미지량
            float damage = laserDamage * Time.deltaTime;            
            if(targetEnemy != null)
            {
                targetEnemy.TakeDamage(damage);
                targetEnemy.Slow(slowRate);
            }
            

            //레이저 빔 그리기
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                impactEffect.Play();
                impactLight.enabled = true;
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);

            //타겟에서 FirePoint를 바라보는 방향 구하기
            Vector3 dir = firePoint.position - target.position;
            impactEffect.transform.position = target.position + dir.normalized / 2f;
            impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}