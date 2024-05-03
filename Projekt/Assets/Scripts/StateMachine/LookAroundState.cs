using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public  class LookAroundState : MyState
{
    MyStateMachine stateMachine;
    private GameObject AI;
    private float coolDownTime = 4;
    public LookAroundState(MyStateMachine _stateMachine, GameObject _AI)
    {
        stateMachine = _stateMachine;
        AI = _AI;
    }

    public override void StartState()
    {
        stateMachine.SetCondition("lookingAround", true);
    }


    public override void RunState()
    {      
        AI.transform.Rotate((Vector3.up * 80)* Time.fixedDeltaTime);
        coolDownTime -= Time.fixedDeltaTime;
        if (coolDownTime <= 0.0f)
        {
            stateMachine.SetCondition("lookingAround", false);
            coolDownTime = 4;
        }
    }
    public override void EndState()
    {
        stateMachine.SetCondition("lookingAround", false);
    }
}
