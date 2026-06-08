using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 빌드 메뉴 UI를 관리하는 클래스
    /// </summary>
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        //BuildManager 싱글톤 인스턴스
        private BuildManager buildManager;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            buildManager = BuildManager.Instance;
        }
        #endregion

        #region Custom Method
        //머신건타워 버튼 클릭시 호출 - public void Selected버튼이름()
        public void SelectedMachineGun()
        {
            Debug.Log("머신건을 선택 했습니다");
            buildManager.SetSelectedTower(buildManager.machineGunPrefab);
        }

        //로켓타워 버튼 클릭시 호출
        public void SelectedRoketTower()
        {
            Debug.Log("로켓 타워를 선택 했습니다");
            buildManager.SetSelectedTower(buildManager.rocketTowerPrefab);
        }
        #endregion
    }
}