using UnityEngine;

namespace MyDefence
{
    //Waypoint들의 정보를 가져오는 클래스
    public class WayPoints : MonoBehaviour
    {
        #region Field
        public static Transform[] wayPoints;
        #endregion

        private void Awake()
        {
            //필드 초기화
            //자식의 갯수를 가져와 웨이포인트 배열 생성
            wayPoints = new Transform[this.transform.childCount];
            for (int i = 0; i < wayPoints.Length; i++)
            {
                wayPoints[i] = this.transform.GetChild(i);
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }
    }
}