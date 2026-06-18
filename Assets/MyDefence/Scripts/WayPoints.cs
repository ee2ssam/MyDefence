using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 적의 이동 경로를 관리하는 클래스
    /// </summary>
    public class WayPoints : MonoBehaviour
    {
        #region Variables
        //웨이포인트 트랜스폼 인스턴스 배열 선언: 전역적 접근 가능
        public static Transform[] points;
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조 points의 배열 요소수 생성
            points = new Transform[transform.childCount];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = transform.GetChild(i);
            }
        }
        #endregion
    }
}