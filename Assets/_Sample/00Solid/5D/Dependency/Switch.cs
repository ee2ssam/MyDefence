using UnityEngine;

namespace Solid.Dependency
{
    //스위치 기능을 하는 오브젝트를 가져다 사용하는 클래스
    public class Switch : MonoBehaviour
    {
        public Door door;
        public Trap trap;

        private bool isActivated = false;

        //한번 누르면 문열리고 다시 한번 누르면 문이 닫힌다
        public void Toggle()
        {
            if(isActivated)
            {
                isActivated = false;
                door.Close();
                //trap.TrapDisable();
            }
            else
            {
                isActivated = true;
                door.Open();
                //trap.TrapEnable();
            }
        }
    }
}
