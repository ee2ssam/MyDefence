using MyDefence;
using UnityEngine;

namespace Sample
{
    public class SingletonTest2 : Singleton<SingletonTest2>
    {
        public int number = 1234;
    }
}