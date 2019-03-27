using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour
{
    GameObject[] waypoints;
    GameObject tankConsta;

    NavMeshAgent agent; 
    TankAI tankAI;

    int shootableMask;
    int waypoint = 0;

    public float range = 10000f;

    Animator anim;



    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        tankConsta = animator.gameObject;
        tankAI = tankConsta.GetComponent<TankAI>();
        shootableMask = LayerMask.GetMask("Shootable");
        agent = tankConsta.GetComponent<NavMeshAgent>();
        agent.destination = waypoints[waypoint].transform.position;
        anim = animator;
        agent.autoBraking = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.destination = waypoints[waypoint].transform.position;
       
        if (agent.remainingDistance >= agent.stoppingDistance)
        {
            waypoint = (waypoint + 1) % waypoints.Length;
        }
        
        checkSomething();
            
    }



    private void checkSomething()
    {
        RaycastHit hit;

        
        if (Physics.Raycast(tankAI.turret.transform.position, tankAI.turret.transform.forward, out hit, Mathf.Infinity,shootableMask))
        {
            Debug.DrawRay(tankAI.turret.transform.position, tankAI.turret.transform.forward * hit.distance, Color.blue);
            tankAI.checkSomething = hit.transform.gameObject;
            anim.SetTrigger("goToChase");
            anim.ResetTrigger("goToPatrol");
            Debug.Log("Gamoto");

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
