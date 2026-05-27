using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    public float speed = 3.0f;
    public float arrivalDistance = 0.1f;

    private void Start()
    {
        //타겟(이동 목적지) 찾아오기
        target = GameObject.FindGameObjectWithTag("End").transform;
    }

    void Update()
    {
        if (target == null) return;

        // 1. 목적지를 향하는 방향(화살표)을 계산합니다.
        // (목적지 위치 - 내 위치)를 구한 뒤, .normalized를 붙이면 순수한 '방향'만 남습니다.
        Vector3 direction = (target.position - transform.position).normalized;

        // 2. transform.Translate를 사용해 계산한 방향으로 이동합니다.
        // 방향 * 속도 * 시간에 비례해서 매 프레임마다 이동하게 됩니다.
        // Space.World를 적어주어야 '적의 앞방향'이 아닌 '월드(세계)의 절대적인 방향'을 기준으로 움직입니다.
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // 3. 목적지까지 거리가 얼마나 남았는지 계산합니다.
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // 4. 도착 판정
        if (distanceToTarget <= arrivalDistance)
        {
            ArriveAtTarget();
        }
    }

    void ArriveAtTarget()
    {
        Debug.Log("종점 도착!!!!");
        Destroy(gameObject);
    }
}