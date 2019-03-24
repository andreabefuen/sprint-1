using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolTiago : baseFSMTiago
{
    // Variables
    GameObject[] waypoints;

    public int currentWP;


    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = tankAI.GetComponent<tankAITiago>().RandomWaypoint();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;

        if (Vector3.Distance(waypoints[currentWP].transform.position, tankAI.transform.position) < accuracy)
        {
            currentWP = tankAI.GetComponent<tankAITiago>().RandomWaypoint();
        }

        // rotates towards WP
        var direction = waypoints[currentWP].transform.position - tankAI.transform.position;

        tankAI.transform.rotation = Quaternion.Slerp(tankAI.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

        tankAI.transform.Translate(0f, 0f, speed * Time.deltaTime);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    

}
