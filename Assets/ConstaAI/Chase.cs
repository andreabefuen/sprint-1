using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : StateMachineBehaviour
{
    GameObject tank;
    Animator anim;
    GameObject[] waypoints;
    GameObject chaseTheTank;
    NavMeshAgent agent;
    TankAI tankAI;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tank = animator.gameObject;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        agent = tank.GetComponent<NavMeshAgent>();
        tankAI = tank.GetComponent<TankAI>();
        chaseTheTank = tankAI.checkSomething;        
    }

    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (tankAI.checkSomething == null)
        {
            animator.ResetTrigger("goToChase");
            animator.SetTrigger("goToPatrol");
        }

        else if (tankAI.checkSomething != null)
        {
           tank.GetComponent<NavMeshAgent>().destination=(tankAI.checkSomething.transform.position);
            tankAI.turret.transform.LookAt(tankAI.checkSomething.transform);

            if (agent.remainingDistance <= 10f)
            {
                animator.SetTrigger("goToAttack");
                animator.ResetTrigger("goToChase");
            }
        }   

       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
