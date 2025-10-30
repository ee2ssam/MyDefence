using UnityEngine;
using System.Collections;

namespace Sample
{
    public class DessolveTest : MonoBehaviour
    {
        #region Variables
        public Renderer renderer;

        private Material originMaterial;
        public Material dessolveMaterial;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            originMaterial = renderer.material;

            //디졸브 이펙트 플레이
            StartCoroutine(SpawnEllen());
        }
        #endregion

        #region Custom Method
        IEnumerator SpawnEllen()
        {
            renderer.material = dessolveMaterial;
            renderer.material.SetFloat("_SplitValue", 0f);

            yield return new WaitForSeconds(0.5f);

            float t = 0f;

            while(t < 1.5f)
            {
                t += Time.deltaTime;
                float value = t / 1.5f;
                renderer.material.SetFloat("_SplitValue", value);

                yield return null;
            }

            renderer.material = originMaterial;
        }
        #endregion

    }
}