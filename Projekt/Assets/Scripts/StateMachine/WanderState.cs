using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : MyState
{
    private NavMeshAgent navMeshAgent;
    private WalkingPoint walkingPoint;
    private int moveSpeed;

    private List<Vector3> mazePoints = new List<Vector3>();

    private GameObject AI;
    private int randPoint;

    
    public WanderState(NavMeshAgent navMeshAgent, int moveSpeed, WalkingPoint walkingPoint, GameObject AI)
    {
        this.navMeshAgent = navMeshAgent;
        this.moveSpeed = moveSpeed;
        this.walkingPoint = walkingPoint;
        this.AI = AI;
    }

    public override void StartState() 
    {
        navMeshAgent.speed = moveSpeed;
        mazePoints = walkingPoint.GetPoints();
        randPoint = Random.Range(0, mazePoints.Count - 1);
        navMeshAgent.SetDestination(mazePoints[randPoint]);
        Debug.Log("WanderState");
    }
    public override void RunState() 
    {
        if ((AI.transform.position - mazePoints[randPoint]).magnitude < 0.4f)
        {
            randPoint = Random.Range(0, mazePoints.Count - 1);
            navMeshAgent.SetDestination(mazePoints[randPoint]);
        }
        
    }
    public override void EndState() { }


}
