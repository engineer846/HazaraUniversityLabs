using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent agent;
    bool isFollowingTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.myEventCaller += MoveToTarget;
    }

    private void Update()
    {
        if (isFollowingTarget)
            agent.SetDestination(Target.position);
    }

    public void MoveToTarget()
    {
        Debug.Log("Event heard by " + this.gameObject.name);
        isFollowingTarget = true;
        //agent.SetDestination(Target.position);
    }
    private void OnDisable()
    {
        EventManager.myEventCaller -= MoveToTarget;
    }
}
