using UnityEngine;

namespace Solid.OpenClose
{
    public class AreaCalculator : MonoBehaviour
    {
        public Rectangle rectangle;
        public Circle circle;


        //매개변수로 받은 도형의 면적 구해서 반환하는 함수
        public float GetShapeArea(Shape shape)
        {
            return shape.CaculateArea();
        }

        private void Start()
        {
            float rectArea = GetShapeArea(rectangle);
            float cirlceArea = GetShapeArea(circle);
        }

        /*//매개변수로 받은 사각형 도형의 면적 구해서 반환하는 함수
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.CaculateArea();
        }

        //매개변수로 받은 원 도형의 면적 구해서 반환하는 함수
        public float GetCircleArea(Circle circle)
        {
            return circle.CaculateArea();
        }*/
    }
}
