using UnityEngine;

namespace Solid
{
    //사각형 클래스
    public class Rectangle
    {
        public float width;
        public float height;
    }

    //원 클래스
    public class Circle
    {
        public float radius;
    }

    //삼각형 클래스
    //...


    //도형의 면적을 구하는 클래스
    public class UnRefactoredAreaCalculator : MonoBehaviour
    {
        //매개변수로 받은 사각형 도형의 면적 구해서 반환하는 함수
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.width * rectangle.height;
        }

        //매개변수로 받은 원 도형의 면적 구해서 반환하는 함수
        public float GetCircleArea(Circle circle)
        {
            return circle.radius * circle.radius * Mathf.PI;
        }

        //매개변수로 받은 삼각형 도형의 면적 구해서 반환하는 함수
        //...
    }
}