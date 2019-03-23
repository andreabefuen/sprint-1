using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTiago : baseFSMTiago
{
    // Variables
    GameObject sphere = null;
    GameObject prefab;
    Vector3 direction;

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
            var resetPos = new Vector3 (0, 0, 3);
            sphere.transform.localPosition = resetPos;
            sphere.GetComponent<Collider>().enabled = false;
            //sphere.GetComponent<MeshRenderer>().enabled = false
        }

        if (targetTank == null)
            Destroy(sphere);

        if (sphere != null)
        {
            direction = sphere.transform.position - tankAI.transform.position;
            direction.y = 0f;
        }

        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.LookRotation(direction), lookSpeed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tankAI.GetComponent<tankAITiago>().StopFiring();
    }

}
