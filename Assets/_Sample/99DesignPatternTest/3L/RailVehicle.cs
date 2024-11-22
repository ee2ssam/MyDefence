using UnityEngine;

namespace Solid
{
    public class RailVehicle : IMovable
    {
        public void GoForward()
        {
            //철도 탈것이 앞으로 간다
        }

        public void GoBack()
        {
            //철도 탈것이 후진한다
        }
    }


    public class Train : RailVehicle
    {

    }
}
