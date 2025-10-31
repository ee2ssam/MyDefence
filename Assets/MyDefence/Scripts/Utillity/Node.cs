using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Waypoint의 노드 클래스
    /// </summary>
    public class Node : MonoBehaviour
    {
        #region Variables
        //현재 노드에 도착한 후 다음에 이동할 노드
        [SerializeField]
        private Node next;
        #endregion

        #region Custom Method
        public Node GetNextNode()
        {
            return next;
        }
        #endregion
    }
}