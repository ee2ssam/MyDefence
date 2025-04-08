using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Field
        public TowerBluePrint machineGunTower;
        public TowerBluePrint rocketTower;
        #endregion


        //MachineGunButton 클릭시 호출되는 함수
        public void MachineGunButton()
        {
            //빌드매니저의 towerToBuild에 machineGunPrefab을 저장한다
            Debug.Log("towerToBuild에 machineGunPrefab을 저장한다");
            BuildManager.Instance.SetTowerToBuild(machineGunTower.towerPrefab);
        }

        //RocketTowerButton 클릭시 호출되는 함수
        public void RocketTowerButton()
        {
            Debug.Log("towerToBuild에 rocketTowerPrefab을 저장한다");
            BuildManager.Instance.SetTowerToBuild(rocketTower.towerPrefab);
        }
    }
}