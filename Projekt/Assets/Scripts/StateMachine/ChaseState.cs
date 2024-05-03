using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : MyState
{
    private float moveSpeed;
    private NavMeshAgent navMeshAgent;
    private GameObject targetObject;
    private GameObject AI;

    public ChaseState(float moveSpeed, NavMeshAgent navMeshAgent, GameObject targetObject, GameObject _AI)
    {
        this.moveSpeed = moveSpeed;
        this.navMeshAgent = navMeshAgent;
        this.targetObject = targetObject;
        AI = _AI;
    }

    public override void StartState() 
    {
        navMeshAgent.speed = moveSpeed;
        Debug.Log("Chasing");
    }

    private protected void RotateTowards(Transform transform, Transform target, float speed)
    {
        Vector3 targetDirection = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z);
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    public override void RunState()
    {
        RotateTowards(AI.transform, targetObject.transform, 5);
        if ((AI.transform.position - targetObject.transform.position).magnitude > 0.4f)
        {
            navMeshAgent.SetDestination(targetObject.transform.position);
        }
        else
        {
            navMeshAgent.SetDestination(AI.transform.position);
        }
    }
    public override void EndState() 
    {
       
    }
}
