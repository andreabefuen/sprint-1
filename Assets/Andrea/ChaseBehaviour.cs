using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    GameObject tank;
    Animator anim;
    GameObject[] waypointList;
    GameObject chaseTank;
    NavMeshAgent navMeshAgent;
    TankStats tankStats;

     
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tank = animator.gameObject;
        
        navMeshAgent = tank.GetComponent<NavMeshAgent>();
        tankStats = tank.GetComponent<TankStats>();

        chaseTank = tankStats.tankToSee;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(chaseTank != null)
        {
            tankStats.tankTurret.LookAt(chaseTank.transform.position);
            navMeshAgent.destination = chaseTank.transform.position;

            if (Vector3.Distance(chaseTank.transform.position, tank.transform.position) < tankStats.distanceShoot)
            {
                animator.SetBool("attack", true);
            }
        }
        else
        {
            animator.SetBool("attack", false);
            animator.SetBool("chase", false);
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
}
