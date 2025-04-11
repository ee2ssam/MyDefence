using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Field
        //타워(건설) 정보를 가지고 있는 객체
        public TowerBluePrint machineGunTower;
        public TowerBluePrint rocketTower;
        public TowerBluePrint laserTower;
        #endregion


        //MachineGunButton 클릭시 호출되는 함수
        public void MachineGunButton()
        {
            //빌드매니저의 towerToBuild에 machineGun을 저장한다
            BuildManager.Instance.SetTowerToBuild(machineGunTower);
        }

        //RocketTowerButton 클릭시 호출되는 함수
        public void RocketTowerButton()
        {
            BuildManager.Instance.SetTowerToBuild(rocketTower);
        }

        //LaserTowerButton 클릭시 호출되는 함수
        public void LaserTowerButton()
        {
            BuildManager.Instance.SetTowerToBuild(laserTower);
        }
    }
}