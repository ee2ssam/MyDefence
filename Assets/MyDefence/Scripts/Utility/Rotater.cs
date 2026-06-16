using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 오브젝트를 지정한 방향으로 회전(연출)시키는 클래스
    /// </summary>
    public class Rotater : MonoBehaviour
    {
        [SerializeField]
        private Vector3 rotationSpeed;

        private void Update()
        {
            //회전
            transform.localEulerAngles += rotationSpeed;
        }
    }
}