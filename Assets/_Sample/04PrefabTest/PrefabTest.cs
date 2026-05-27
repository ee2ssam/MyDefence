using UnityEngine;

namespace MySample
{
    public class PrefabTest : MonoBehaviour
    {
        #region Variables
        //생성할 프리팹 게임 오브젝트 원본 가져오기
        public GameObject prefab;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //[1] 프리팹 게임오브젝트의 사본 만들기
            Instantiate(prefab);

            //[2] 지정된 위치(5, 0.05, 8)에 프리팹 게임오브젝트의 사본 만들기
            Instantiate(prefab, new Vector3(5.0f, 0.05f, 8f), Quaternion.identity);

        }
        #endregion

    }
}

/*



*/