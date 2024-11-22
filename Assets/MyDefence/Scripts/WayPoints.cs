using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDefence
{
    //Waypoint들을 관리하는 클래스
    public class WayPoints : MonoBehaviour
    {
        //필드
        public static Transform[] points;

        private void Awake()
        {
            points = new Transform[this.transform.childCount];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = this.transform.GetChild(i);
            }
        }

    }
}