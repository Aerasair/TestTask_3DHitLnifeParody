using UnityEngine;

public class WaypointsKillCounter : MonoBehaviour
{

    [SerializeField] public WayPointsMobs[] _wayPoint;
    private int _currentWayPointIndex;

    public void KillMob()
    {
        _wayPoint[_currentWayPointIndex].QuantityMobsOnWayPoint--;
        if (_wayPoint[_currentWayPointIndex].QuantityMobsOnWayPoint ==  0)
            _currentWayPointIndex++;
        
    }
}
