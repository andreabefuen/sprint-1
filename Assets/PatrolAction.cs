using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAction : StateMachineBehaviour
{
    
    GameObject tank;
    Animator anim;
    GameObject[] waypointList;

    NavMeshAgent navMeshAgent;
    TankStats tankStats;

    int count = 0;
    int shootableMask;
    




    private void Awake()
    {
        waypointList = GameObject.FindGameObjectsWithTag("waypoint");
        
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        tank = animator.gameObject;
        navMeshAgent = tank.GetComponent<NavMeshAgent>();
        tankStats = tank.GetComponent<TankStats>();

        shootableMask = LayerMask.GetMask("Shootable");
        anim = animator;


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.destination = waypointList[count].transform.position;
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            Debug.Log("AL OTRO PUNTO");
            count = (count + 1) % waypointList.Length;
            
        }
        SeeSomething();
        //Look();
    }

    private void SeeSomething()
    {

        RaycastHit hit;

        if (Physics.Raycast(tankStats.fireTransform.position, tankStats.fireTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootableMask))
        {
            Debug.DrawRay(tankStats.fireTransform.position, tankStats.fireTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            tankStats.tankToSee = hit.transform.gameObject;
            anim.SetBool("chase", true);
            Debug.Log("Ha visto algo");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}


    void Look()
    {
        RaycastHit hit;

        if (Physics.Raycast(tankStats.fireTransform.position, tankStats.fireTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootableMask))
        {
            Debug.DrawRay(tankStats.fireTransform.position, tankStats.fireTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            tankStats.tankTurret.LookAt(hit.transform);
            tankStats.tankToSee = hit.transform.gameObject;
            anim.SetBool("chase", true);
            Debug.Log("Ha visto algo");
        }

    }
}
