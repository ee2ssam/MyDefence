using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 오브젝트를 지정한 시간에 킬 시키는 클래스
    /// </summary>
    public class Destruction : MonoBehaviour
    {
        //지정한 시간
        public float destructTime = 1f;

        private void Start()
        {
            //지정한 시간에 킬 예약
            Destroy(this.gameObject, destructTime);
        }
    }
}