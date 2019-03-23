using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiguelAIBaseFSM : StateMachineBehaviour
{
    public GameObject MiguelAI;
    //public GameObject opponent;
    public float speed = 2.0f;
    public float rotSpeed = 4.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MiguelAI = animator.gameObject;
        
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //opponent = MiguelAI.GetComponent<MiguelTankAI>().GetEnemy();
    }
}
