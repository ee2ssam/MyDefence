using UnityEngine;

namespace MyDefence
{
    //타워 건설을 관리하는 싱글톤 패턴 클래스
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Field
        //타일에 설치할 타워 정보를 저장하는 변수
        private TowerBluePrint towerToBuild;
        
        #endregion

        private void Start()
        {
            //초기화
        }
        
        //타일에 설치할 타워 정보를 얻어오기
        public TowerBluePrint GetTowerToBuild()
        {
            return towerToBuild;
        }

        //타일에 설치할 타워 프리팹 오브젝트 저장하기
        public void SetTowerToBuild(TowerBluePrint tower)
        {
            towerToBuild = tower;
        }
    }
}