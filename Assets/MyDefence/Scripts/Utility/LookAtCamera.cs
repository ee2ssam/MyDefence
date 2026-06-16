using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임 오브젝트 항상 카메라를 바라보도록 한다
    /// </summary>
    public class LookAtCamera : MonoBehaviour
    {
        #region Variables
        //메인카메라 인스턴스
        private Camera mainCamera;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            mainCamera = Camera.main;
        }

        private void Update()
        {
            //항상 카메라를 바라본다
            //transform.LookAt(mainCamera.transform.position);

            //카메라의 x 포지션을 오브젝트의 x 포지션을 동일하게 한다
            Vector3 targetPostion = new Vector3( this.transform.position.x,
                mainCamera.transform.position.y, mainCamera.transform.position.z);
            transform.LookAt(targetPostion);

        }
        #endregion
    }
}