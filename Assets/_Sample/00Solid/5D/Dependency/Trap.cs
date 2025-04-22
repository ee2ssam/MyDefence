using UnityEngine;

namespace Solid.Dependency
{
    public class Trap : MonoBehaviour
    {
        public void TrapEnable()
        {
            Debug.Log("트랩 활성화");
        }

        public void TrapDisable()
        {
            Debug.Log("트랩 비활성화");
        }
    }
}
