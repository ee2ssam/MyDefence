using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// WayPoint(적이 지나가는 길의 분기점)들을 관리하는 클래스
    /// </summary>
    public class WayPoints : MonoBehaviour
    {
        #region Variables
        //WayPoint(적이 지나가는 길의 분기점)들의 오브젝트를 저장하는 배열
        public static Transform[] points;
        #endregion

        #region Unity Evnet Method
        private void Awake()
        {
            //초기화
            //WayPoint 배열 요소수 생성 - WayPoint 갯수 가져오기
            points = new Transform[this.transform.childCount];
            //Debug.Log($"WayPoint의 갯수: {this.transform.childCount}");

            for (int i = 0; i < points.Length; i++)
            {
                //WayPoint의 transform을 순서대로 가져와서 배열에 저장하기
                points[i] = this.transform.GetChild(i);
            }
        }
        #endregion
    }
}