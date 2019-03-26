using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTiago : baseFSMTiago
{
    // Variables
    GameObject prefab;
    Vector3 direction;
    Vector3 targetCurrentPos, targetLastPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        tankAI.GetComponent<tankAITiago>().StartFiring();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // create the target point, so that bullet targeting this point can hit the tank
        if (targetTank.transform.Find("Sphere") == null)
        {
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            sphere.transform.parent = targetTank.transform;
            sphere.transform.localPosition = new Vector3(0, 0, 3);
            sphere.GetComponent<Collider>().enabled = false;
            sphere.GetComponent<MeshRenderer>().enabled = false;
        }



        if (targetTank.transform.Find("Sphere") != null)
        {
            sphere = targetTank.transform.Find("Sphere").gameObject;

            direction = sphere.transform.position - tankAI.transform.position;
            direction.y = 0f;

            // predicts where to shoot based on tank position. If tank is moving, shoot a little bit in front. If tank stopped, shoot directly at it
            targetCurrentPos = targetTank.transform.position;

            if (targetCurrentPos == targetLastPos)
            {
                sphere.transform.localPosition = new Vector3(0, 0, 0);
                Debug.Log("sphere in Zero 0");
            }

            else
            {
                sphere.transform.localPosition = new Vector3(0, 0, 3);
                Debug.Log("sphere in Three 3");
            }
                
            targetLastPos = targetCurrentPos;
        }

        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.LookRotation(direction), lookSpeed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tankAI.GetComponent<tankAITiago>().StopFiring();
        Destroy(sphere);
        animator.SetBool("hasTarget", false);
    }
}
