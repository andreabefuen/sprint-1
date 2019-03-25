using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{

    GameObject tank;
    Animator anim;
    GameObject[] waypointList;
    GameObject chaseTank;
    TankStats tankStats;

    int shootableMask;

    float timeBetweenFires;
    float timeAfterFire;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tank = animator.gameObject;

        tankStats = tank.GetComponent<TankStats>();
        chaseTank = tankStats.tankToSee;


        shootableMask = LayerMask.GetMask("Shootable");

        timeBetweenFires = tankStats.timeBetweenFire;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeAfterFire += Time.deltaTime;

        if (timeAfterFire >= timeBetweenFires)
        {
            Shoot(animator);
        }

        if(tankStats.tankToSee == null)
        {
            animator.SetBool("attack", false);
            animator.SetBool("chase", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    void Shoot(Animator animator)
    {
        RaycastHit hit;



        if (Physics.Raycast(tankStats.fireTransform.position, tankStats.fireTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootableMask))
        {
            Debug.DrawRay(tankStats.fireTransform.position, tankStats.fireTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("SHOOOT");
            Rigidbody shellInstance = Instantiate(tankStats.shell, tankStats.fireTransform.position, tankStats.fireTransform.rotation) as Rigidbody;
            tankStats.tankTurret.LookAt(hit.transform);
            tankStats.tankToSee = hit.transform.gameObject;
            shellInstance.velocity = tankStats.launchForce * tankStats.fireTransform.forward;
            //audio
            timeAfterFire = 0f;
            //tankStats.StopMovement();


        }
        else
        {

            //Debug.DrawRay(fireTransform.position, fireTransform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
            //Debug.Log("NOT SHOOTING");
           // tankStats.ContinueMovement();
           
            animator.SetBool("attack", false);
        }
    }
}
