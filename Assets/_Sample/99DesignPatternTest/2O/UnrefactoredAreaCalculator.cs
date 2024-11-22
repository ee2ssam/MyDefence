using UnityEngine;

namespace Solid
{
    public class UnrefactoredAreaCalculator
    {
        //매개변수로 사각형을 받아 면적은 반환하는 함수
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.Width * rectangle.Height;
        }

        //매개변수로 원을 받아 면적은 반환하는 함수
        public float GetCircleArea(Circle circle)
        {
            return circle.Radius * circle.Radius * Mathf.PI;
        }

    }

    //사각형 클래스
    public class Rectangle
    {
        public float Width;
        public float Height;
    }

    //원 클래스
    public class Circle
    {
        public float Radius;
    }
}