using UnityEngine;

namespace Sample
{
    public class BulletTest : MonoBehaviour
    {
        #region Variables
        public Rigidbody rb;
        [SerializeField] private float force = 70f;
        #endregion

        //앞으로 이동
        public void MoveForward()
        {
            Debug.Log("앞으로 이동한다");
            //transform.Translate(transform.forward * Time.deltaTime * 50f, Space.World);
        }

        //앞방향으로 힘을 준다
        public void MoveByForce()
        {
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}