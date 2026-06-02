using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워 건설을 관리하는 싱글톤 클래스
    /// </summary>
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Variables
        //선택한 타워 게임오브젝트 - 타일에 설치할 프리팹 오브젝트
        private GameObject selectedTower;

        //타워 프리팹
        public GameObject machineGunPrefab;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //머신건 프리팹 선택
            selectedTower = machineGunPrefab;
        }
        #endregion

        #region Custom Method
        //선택한 타워 프리팹 오브젝트 반환
        public GameObject GetSelectedTower()
        {
            return selectedTower;
        }
        #endregion
    }
}