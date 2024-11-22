using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    public class LazerBeamer : Turret
    {
        #region Variables
        //레이저 빔
        private LineRenderer lineRenderer;
        //레이저 빔 이펙트
        public ParticleSystem impactEffect;
        //레이저 이펙트 라이트
        public Light impactLight;

        //레이저 데미지
        [SerializeField] private float lazerDamage = 30f;
        //초당 30 데미지
        [SerializeField] private float speed = 30f;
        //Enemy 속도 40% 감속
        [SerializeField] private float slowRate = 0.4f;
        #endregion

        protected override void Start()
        {
            base.Start();

            lineRenderer = GetComponent<LineRenderer>();
        }

        void Update()
        {
            //0.5초마다 타겟 찾기 실행
            /*if (countdown <= 0f)
            {
                //타이머 실행문
                UpdateTarget();

                //타이머 초기화
                countdown = serachTimer;
            }
            countdown -= Time.deltaTime;*/

            //타겟을 찾지 못했으면
            if (target == null)
            {
                //레이저를 그리지 않기 시작하기
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
                return;
            }

            //타겟을 향해 총구를 회전
            LockOn();

            //레이저 쏘기
            Lazer();            
        }

        void Lazer()
        {
            //레이저 타격 데미지 주기 - 1초당 30 데미지
            float damage = Time.deltaTime * lazerDamage;
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            //레이저 타격하는 동안 Enemy의 속도 40% 감속
            EnemyMove enemyMove = target.GetComponent<EnemyMove>();
            if (enemyMove != null)
            {
                enemyMove.Slow(slowRate);
            }


            //레이저를 그리기 시작하기
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                impactEffect.Play();
                impactLight.enabled = true;
            }

            //라인렌더러 그리기 - 시작지점, 끝지점 지정
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);

            //레이저 임펙트 효과 그리기
            Vector3 dir = firePoint.position - target.position;
            impactEffect.transform.position = target.position + dir.normalized * 0.5f;
            impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}