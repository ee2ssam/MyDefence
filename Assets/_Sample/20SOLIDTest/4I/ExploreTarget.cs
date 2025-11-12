using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 전투 가능, 죽음시 폭발하는 유닛
    /// </summary>
    public class ExploreTarget : Target, IExploreable
    {

        protected override void Die()
        {
            base.Die();

            Explore();
        }

        public void Explore()
        {
            throw new System.NotImplementedException();
        }
    }
}