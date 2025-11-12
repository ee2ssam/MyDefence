using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 온오프 기능 정의
    /// </summary>
    public interface ISwitchable
    {
        public bool IsActive { get; set; }

        public void Activate();
        public void Deactivate();
    }
}