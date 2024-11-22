using UnityEngine;

namespace Sample
{
    public class MoveS : MonoBehaviour
    {
        public float moveSpeed = 1.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}