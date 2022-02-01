using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(InputPlayer))]
public class WaypointTransition : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _waypoints;
    private bool _isMoving;

    [SerializeField] private InputPlayer _inputPlayer;

    [SerializeField] private WaypointsKillCounter _waypointsKillCounter;

    private int _currentWayPoint;

    private void Start()
    {
        _currentWayPoint = 0;
        _navMeshAgent.updateRotation = true;
    }

    private void Update()
    {
        if (_isMoving)
           GoToNextWayPoint();
    }

    public void GoToNextWayPoint()
    {
        Vector3 currentTarget = _waypoints[_currentWayPoint].transform.position;

        _navMeshAgent.SetDestination(currentTarget);

        _isMoving = false;
    }

    private void SwapMovingState()
    {
        if (_waypointsKillCounter._wayPoint[_currentWayPoint].QuantityMobsOnWayPoint == 0)
        {
            _isMoving = true;
            _currentWayPoint++;
        }
    }

    private void OnEnable()
    {
        _inputPlayer.ButtonPressed.AddListener(SwapMovingState);
    }

    private void OnDisable()
    {
        _inputPlayer.ButtonPressed.RemoveListener(SwapMovingState);
    }
}
