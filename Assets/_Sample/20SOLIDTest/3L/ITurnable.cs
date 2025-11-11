using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 회전에 대한 기능 정의
    /// </summary>
    public interface ITurnable
    {
        public void TurnLeft();         //좌회전에 대한 정의
        public void TurnRight();        //우회전에 대한 정의
    }
}
