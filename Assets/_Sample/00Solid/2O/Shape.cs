using UnityEngine;
using UnityEngine.UIElements;

namespace Solid.OpenClose
{
    //모든 도형의 부모 클래스
    public abstract class Shape
    {
        //도형의 면적을 구해서 반환하는 함수
        public abstract float CaculateArea();
    }

    public class Rectangle : Shape
    {
        private float width;
        private float heigth;

        //도형의 면적을 구해서 반환하는 함수
        public override float CaculateArea()
        {
            return width * heigth;
        }
    }

    public class Circle : Shape
    {
        public float radius;

        //도형의 면적을 구해서 반환하는 함수
        public override float CaculateArea()
        {
            return radius * radius * Mathf.PI;
        }
    }

}