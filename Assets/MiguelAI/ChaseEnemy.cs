using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MiguelAIBaseFSM
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //rotate towards character
        GameObject enemyToAttack = MiguelAI.GetComponent<MiguelTankAI>().LookForClosestEnemy();
        int safeDistance = 5;

        if (Vector3.Distance(enemyToAttack.transform.position, MiguelAI.transform.position) > safeDistance)
        {
            var direction = enemyToAttack.transform.position - MiguelAI.transform.position;
            MiguelAI.transform.rotation = Quaternion.Slerp(MiguelAI.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            MiguelAI.transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
	
	}
}
