using UnityEngine;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        //MachineGunButton 클릭시 호출되는 함수
        public void MachineGunButton()
        {
            //빌드매니저의 towerToBuild에 machineGunPrefab을 저장한다
            Debug.Log("towerToBuild에 machineGunPrefab을 저장한다");
            BuildManager.Instance.SetTowerToBuild(BuildManager.Instance.machineGunPrefab);
        }
    }
}