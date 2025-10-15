using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워 선택 UI를 관리하는 클래스
    /// </summary>
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        //BuildManager(싱글톤) 객체 선언
        private BuildManager buildManager;

        //타워 리스트
        public TowerBlueprint machineGun;
        public TowerBlueprint rocketTower;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            buildManager = BuildManager.Instance;
        }
        #endregion

        #region Custom Method
        //머신건 버튼 선택시 호출되는 함수
        public void SelectMachineGun()
        {
            //Debug.Log("머신건 타워를 선택하였습니다");
            buildManager.SetTurretToBuild(machineGun);
        }

        //로컷타워 버튼 선택시 호출되는 함수
        public void SelectRocketTower()
        {
            //Debug.Log("로켓 타워 프리팹를 건설될 타워에 저장하였습니다");
            buildManager.SetTurretToBuild(rocketTower);
        }
        #endregion
    }
}