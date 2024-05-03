using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyStateMachine : MonoBehaviour
{
    private List<Transition> transitions = new List<Transition>();
    private List<Condition> conditions = new List<Condition>();

    private MyState currentState;
   // private MyState anyState;

    Transition transition0;
    Transition transition1;
    Transition transition2;
   

    private GameObject player;
    [SerializeField] private int range;
    WanderState wanderState;
    ChaseState chaseState;
    LookAroundState lookingAroundState;
    private Condition rangeCondition;
    private Condition lookingAroundCond;
    public bool inRange;

   
    private void Start()
    {

        rangeCondition = new Condition("inRangeCondition");
        conditions.Add(rangeCondition);

        lookingAroundCond = new Condition("lookingAround");
        conditions.Add(lookingAroundCond);

        player = TargetObject.Instance.gameObject;
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();

        wanderState = new WanderState(navMeshAgent,1, WalkingPoint.Instance, this.gameObject);
        chaseState = new ChaseState(1.5f, navMeshAgent, player, this.gameObject);
        lookingAroundState = new LookAroundState(this, this.gameObject);



        transition0 = new Transition(null, chaseState, rangeCondition, true);
        transition1 = new Transition(lookingAroundState, wanderState, lookingAroundCond, false);
        //transition2 = new Transition(chaseState, lookingAroundState, rangeCondition, false);

        transitions.Add(transition0);
        transitions.Add(transition1);
        //transitions.Add(transition2);

        currentState = wanderState;
        currentState.StartState();
    }


    private void Update()
    {
        
        MyState nextState = null;
        int passedStatets = 0;
        bool changeCurrentState = false;


        for (int i = 0; i < transitions.Count; i++)
        {
            if (transitions[i].GetPass())
            {
                if (transitions[i].GetFrom() == null)
                {
                    if (transitions[i].GetTo() != currentState)
                    {
                        nextState = transitions[i].GetTo();
                        passedStatets++;
                        changeCurrentState = true;
                    }
                }
                else if (transitions[i].GetFrom() == currentState)
                {

                    if (transitions[i].GetTo() != currentState)
                    {
                        nextState = transitions[i].GetTo();
                        passedStatets++;
                        changeCurrentState = true;
                    }

                }
            }

        }
        if (passedStatets > 1)
        {
            Debug.LogWarning("Too many passed States. Amount: " + passedStatets);
        }

        if (changeCurrentState)
        {
            currentState.EndState();
            nextState.StartState();
            currentState = nextState;
        }
        currentState.RunState();
    }


    public Condition GetCondition(string name)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            if (conditions[i].GetName() == name)
            {
                return conditions[i];
            }
        }
        Debug.LogWarning("StateMachine does not contain Condition with the name: " + name);
        return null;
    }
    public void SetCondition(string name, bool value)
    {
        int counter = 0;
        for (int i = 0; i < conditions.Count; i++)
        {
            if (conditions[i].GetName() == name)
            {
                conditions[i].SetCondition(value);
                counter++;
            }
        }

        if (counter < 1)
        {
            Debug.LogWarning("StateMachine does not contain Condition with the name: " + name);
        }
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,transform.position + transform.forward);
    } */
} 
