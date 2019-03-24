using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class baseFSMTiago : StateMachineBehaviour
{
    // Variables
    public GameObject tankAI;
    public GameObject targetTank;
    public GameObject turret;
    public GameObject sphere;

    public float rotSpeed = 1;
    public float accuracy = 3;

    // fetched values from tankAI
    public float speed;
    public float distance;
    public float lookSpeed;

    public bool evade;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tankAI = animator.gameObject;
        targetTank = tankAI.GetComponent<tankAITiago>().GetTarget();
        turret = tankAI.GetComponent<tankAITiago>().GetTurret();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        speed = tankAI.GetComponent<tankAITiago>().GetSpeed();
        distance = tankAI.GetComponent<tankAITiago>().GetTargetDistance();
        lookSpeed = tankAI.GetComponent<tankAITiago>().GetLookSpeed();

        if (targetTank == null)
            Destroy(sphere);
    }

}
