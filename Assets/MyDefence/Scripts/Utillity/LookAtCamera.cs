using UnityEngine;

namespace MyDefence
{
    //게임 오브젝트가 메인 카메라를 바라보게 만드는 클래스
    public class LookAtCamera : MonoBehaviour
    {
        #region Variables
        private Camera mainCamera;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.LookAt(mainCamera.transform);
        }
    }
}