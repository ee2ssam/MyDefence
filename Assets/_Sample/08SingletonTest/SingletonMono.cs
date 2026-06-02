using UnityEngine;

namespace MySample
{
    /// <summary>
    /// MonoBehaviour를 상속받은 클래스의 싱글톤 패턴 디자인
    /// 게임오브젝트에 부착되는 싱글톤 패턴 클래스 디자인
    /// 하이라킹 창에 싱글톤 패턴 클래스가 부착되어 있는 게임오브젝트가 1개만 존재하도록 디자인
    /// </summary>
    public class SingletonMono : MonoBehaviour
    {
        //SingletonMono 클래스의 인스턴스(객체) 정적(static)변수 선언
        private static SingletonMono instance;

        //public한 속성으로 private한 instance에 전역적으로 접근하기
        public static SingletonMono Instance
        {
            get
            {
                return instance;
            }
        }

        //가장 먼저 호출되는 함수 - 오브젝트가 하나만 존재하게 해준다
        private void Awake()
        {
            //싱글톤 패턴 클래스가 부착되어 있는 오브젝트가 존재 체크
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            //null 이면
            instance = this;

            //씬 종료시 이 스크립트가 부착되어 있는 오브젝트는 삭제하지 않는다
            //DontDestroyOnLoad(this.gameObject);
        }

        //멤버변수, 필드
        public int number;
    }
}