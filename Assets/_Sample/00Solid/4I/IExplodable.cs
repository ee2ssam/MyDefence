using UnityEngine;

namespace Solid.Interface
{
    //폭발 오브젝트의 기능 정의
    public interface IExplodable
    {
        public float Mass { get; set; }
        public float ExplosiveForce { get; set; }
        public float FuseDelay { get; set; }
        public void Explode();
    }
}
