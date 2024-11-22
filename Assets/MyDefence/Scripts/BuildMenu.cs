using UnityEngine;

namespace MyDefence
{
    //건설할 터렛 선택을 관리하는 클래스
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;

        //기본 터렛 품목 정보(프리팹, 가격)
        public TurretBlueprint basicTurret;
        //미사일 런처 품목 정보(프리팹, 가격)
        public TurretBlueprint missileLauncher;
        //레이저 빔머 품목 정보(프리팹, 가격)
        public TurretBlueprint lazerBeamer;
        #endregion

        private void Start()
        {
            //초기화
            buildManager = BuildManager.Instance;
        }


        //기본 터렛 버튼을 클릭시 호출
        public void SelectBasicTurret()
        {
            //설치할 터렛에 기본 터렛(프리팹)을 저장
            buildManager.SetTurretToBuild(basicTurret);
        }

        //미사일 런처 버튼 클릭시 호출
        public void SelectMissileLauncher()
        {
            //설치할 터렛에 미사일 런처(프리팹)을 저장
            buildManager.SetTurretToBuild(missileLauncher);
        }

        //레이저 빔머 버튼 클릭시 호출
        public void SelectLazerBeamer()
        {
            //설치할 터렛에 레이저 빔머(프리팹)을 저장
            buildManager.SetTurretToBuild(lazerBeamer);
        }
    }
}