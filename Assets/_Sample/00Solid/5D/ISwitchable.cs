using UnityEngine;

namespace Solid
{
    //스위치 기능 정의
    public interface ISwitchable
    {
        public bool IsActive { get; }
        public void Activate();
        public void Deactivate();
    }
}
