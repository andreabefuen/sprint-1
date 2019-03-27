using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : StateMachineBehaviour
{
    GameObject tank;
    Animator anim;
    GameObject[] waypoints;
    GameObject chaseTheTank;
    TankAI tankAI;

    int shootableMask;

    float timeOnFire;
    float afterFire;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tank = animator.gameObject;
        tankAI = tank.GetComponent<TankAI>();
        chaseTheTank = tankAI.checkSomething;
        shootableMask = LayerMask.GetMask("Shootable");
        timeOnFire = 5f;
        afterFire = 0f;
        tankAI.GetComponent<TankAI>().StartFiring();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        afterFire += Time.deltaTime;

        if (afterFire >= timeOnFire)
        {
            Fire(animator);
        }

        /*if (tankAI.checkSomething == null)
        {
            animator.SetTrigger("goToPatrol");
        }*/

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void Fire(Animator animator)
    {
        RaycastHit hit;
        if (Physics.Raycast(tankAI.turret.transform.position, tankAI.turret.transform.forward, out hit, Mathf.Infinity, shootableMask))
        {
            Debug.DrawRay(tankAI.turret.transform.position, tankAI.turret.transform.forward * hit.distance, Color.yellow);
            Debug.Log("Gamoto2");
            Rigidbody shellInstance = Instantiate(tankAI.shell, tankAI.turret.transform.position, tankAI.turret.transform.rotation) as Rigidbody;
            tankAI.checkSomething.transform.LookAt(hit.transform);
            tankAI.checkSomething = hit.transform.gameObject;
            shellInstance.velocity = tankAI.powerLaunch * tankAI.turret.transform.forward;
            afterFire = 0f;

        }
        else
        {
            animator.SetTrigger("goToChase");
            animator.ResetTrigger("goToAttack");
        }
    }

}
