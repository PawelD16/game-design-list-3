using UnityEngine;

public class PatrolState : BaseState
{

    private const float MAXIMUM_DISTANCE_WAYPOINT_SWITCH = 0.2f;
    private const float MAXIMUM_WAIT_TIME = 3f;

    public int waypointIndex;
    public float waitTimer;

    public override void Enter() { }

    public override void Exit() { }

    public override void Perform() => PatrolCycle();
   
    public void PatrolCycle()
    {
        if (Enemy.NavMeshAgent.remainingDistance >= MAXIMUM_DISTANCE_WAYPOINT_SWITCH)
            return;

        waitTimer += Time.deltaTime;

        if (waitTimer > MAXIMUM_WAIT_TIME)
        {
            waypointIndex = (waypointIndex + 1) % Enemy.Pathing.Waypoints.Count;
            Enemy.NavMeshAgent.SetDestination(Enemy.Pathing.Waypoints[waypointIndex].position);
            waitTimer = 0f;
        }
    }
}
