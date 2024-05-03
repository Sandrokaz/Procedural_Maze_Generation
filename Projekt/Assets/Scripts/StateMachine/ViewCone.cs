using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCone : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private int range;
    private MyStateMachine stateMachine;
  

    public float angleToTarget;

    private Vector3 targetDir;

    private void Start()
    {
        targetObject = TargetObject.Instance.gameObject;
        stateMachine = GetComponent<MyStateMachine>();
    }
    private void Update()
    {
        angleToTarget = AngleBetween(transform.position, targetObject.transform.position);
        if (angleToTarget <= 45)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, targetDir.normalized, out hit, range))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    
                    Debug.Log("Hit Player" );
                    stateMachine.SetCondition("inRangeCondition", true);
                }
                else
                {
                    stateMachine.SetCondition("inRangeCondition", false);
                }

            }
        }
        else
        {
            stateMachine.SetCondition("inRangeCondition", false);
        }
    }
    float AngleBetween(Vector3 from, Vector3 to)
    {
        targetDir = to - from;
        float angle = Vector3.Angle(targetDir, transform.forward);
        return angle;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}
