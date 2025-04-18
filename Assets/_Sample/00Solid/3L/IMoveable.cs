using UnityEngine;

namespace Solid
{
    //앞으로, 뒤로 이동하는 기능 정의
    public interface IMoveable
    {
        public void GoForward();
        public void GoBack();
    }
}