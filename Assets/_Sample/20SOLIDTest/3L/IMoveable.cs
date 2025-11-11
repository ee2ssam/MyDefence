using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 이동 기능 정의
    /// </summary>
    public interface IMoveable
    {
        public void GoForward();    //앞으로 이동
        public void GoBack();       //뒤로 이동
    }
}