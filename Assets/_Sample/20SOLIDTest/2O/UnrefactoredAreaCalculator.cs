using UnityEngine;

namespace Sample
{
    public class Rectangle
    {
        public float width;
        public float height;
    }

    public class Circle
    {
        public float radius;
    }

    //삼각형, 오각형, 육각형......

    /// <summary>
    /// 리펙토링 이전의 도형의 면적을 구하는 클래스
    /// </summary>
    public class UnrefactoredAreaCalculator : MonoBehaviour
    {
        //사각형 도형의 면적을 구하는 함수
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.width * rectangle.height;
        }

        //원 도형의 면적을 구하는 함수
        public float GetCircleArea(Circle circle)
        {
            return circle.radius * circle.radius * Mathf.PI;
        }

        //삼각형, 오각형, 육각형 등의 면적을 구하는 함수가 각각 필요하다

    }
}