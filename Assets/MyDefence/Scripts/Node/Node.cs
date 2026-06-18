using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 적의 웨이포인트를 관리하는 클래스
    /// 이번 노드 다음으로 이동할 정보만 가지고 있다
    /// </summary>
    public class Node : MonoBehaviour
    {
        //다음 노드
        [SerializeField] private Node[] next;
        //public Node Next => next;

        public Node GetNextNode()
        {
            if(next.Length <= 0)
                return null;

            //랜덤으로 다음 노드 선택
            return next[Random.Range(0, next.Length)];
        }
    }
}