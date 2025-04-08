using UnityEngine;

namespace Sample
{
    public class SerializeTest : MonoBehaviour
    {
        #region Field
        public int number = 10;

        [SerializeField]
        private string name = "홍길동";

        private string car = "avanter";

        [SerializeField]
        private TestStruct testStruct;

        public Transform target;

        public GameObject prefabTest;
        #endregion
    }
}