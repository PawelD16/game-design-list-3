using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer;

    private const float MAXIMUM_DISTANCE_WAYPOINT_SWITCH = 0.2f;
    private const float MAXIMUM_WAIT_TIME = 3f;

    public override void Enter() { }

    public override void Exit() { }

    public override void Perform()
    {
        PatrolCycle();
    }

    public void PatrolCycle()
    {
        if (enemy.NavMeshAgent.remainingDistance >= MAXIMUM_DISTANCE_WAYPOINT_SWITCH)
            return;

        waitTimer += Time.deltaTime;

        if (waitTimer > MAXIMUM_WAIT_TIME)
        {
            waypointIndex = (waypointIndex + 1) % enemy.Pathing.Waypoints.Count;
            enemy.NavMeshAgent.SetDestination(enemy.Pathing.Waypoints[waypointIndex].position);
            waitTimer = 0f;
        }
    }
}
