
using UnityEngine.UIElements;

namespace Sample
{
    namespace ObjectTest
    {
        public class Singleton
        {
            private static Singleton instance;

            //속성 - 읽기전용
            public static Singleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }

            //메서드
            /*public static Singleton Instance()
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }*/
        }
    }
}