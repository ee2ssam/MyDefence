using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // [Inspector] 창에서 복사할 Enemy 프리팹을 넣어줄 칸입니다.
    public GameObject enemyPrefab;

    // 적이 태어날 스폰 지점(시작점)의 위치 정보입니다.
    public Transform spawnPoint;

    // 웨이브 사이의 대기 시간 (5초)
    public float waveInterval = 5.0f;

    // 현재 몇 번째 웨이브인지 기억하는 변수 (1부터 시작!)
    private int currentWave = 1;

    void Start()
    {
        // 게임이 시작되면 'SpawnLoop'라는 이름의 코루틴 비서를 실행시킵니다.
        StartCoroutine(SpawnLoop());
    }

    // 5초마다 반복하며 적을 스폰하는 코루틴 함수입니다.
    IEnumerator SpawnLoop()
    {
        // 게임이 켜져 있는 동안 무한히 반복합니다.
        while (true)
        {
            // Console 창에 현재 어떤 웨이브가 시작되었는지 알려줍니다.
            Debug.Log($"{currentWave}번째 웨이브 시작! (적 {currentWave}마리 생성)");

            // 현재 웨이브 숫자만큼 반복해서 적을 생성합니다.
            // (예: 1번째 웨이브면 1번, 3번째 웨이브면 3번 반복)
            for (int i = 0; i < currentWave; i++)
            {
                // Instantiate(무엇을, 어디에, 어떤 회전값으로) 생성할지 정합니다.
                // Quaternion.identity는 '회전 없음(똑바로)'을 의미해요.
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

                // 만약 적들이 완전히 겹쳐서 태어나는 게 싫다면, 
                // 생성될 때 아주 잠깐의 간격(예: 0.2초)을 두고 태어나게 할 수도 있어요.
                yield return new WaitForSeconds(0.2f);
            }

            // 다음 웨이브를 위해 웨이브 번호를 1 증가시킵니다. (1 -> 2 -> 3...)
            currentWave++;

            // 지정한 시간(5초) 동안 아무것도 하지 않고 가만히 기다립니다.
            yield return new WaitForSeconds(waveInterval);
        }
    }
}