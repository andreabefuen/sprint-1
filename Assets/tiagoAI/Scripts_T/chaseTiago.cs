using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseTiago : baseFSMTiago
{
    // Variables
    public Vector3 targetPos;
    public Vector3 currentPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("hasTarget", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentPos = tankAI.transform.position;
        targetPos = targetTank.transform.position;

        // direction of target
        var direction = targetPos - currentPos;

        /*  UNUSED WHILE USING NAVMESH
         *
            tankAI.transform.rotation = Quaternion.Slerp(tankAI.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            tankAI.transform.Translate(0, 0, speed * Time.deltaTime);
        */

        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        tankAgent.SetDestination(targetTank.transform.position);


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
}
