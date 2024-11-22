using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class CubeController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //앞으로 이동
            //transform.Translate(Vector3.forward * Time.deltaTime);
        }

        // Update is called once per frame
        void Update()
        {
            //앞으로 이동
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}