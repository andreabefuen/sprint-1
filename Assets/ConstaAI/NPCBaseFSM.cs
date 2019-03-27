using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject ConsAI;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 0.3f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ConsAI = animator.gameObject;
        
    }
}
