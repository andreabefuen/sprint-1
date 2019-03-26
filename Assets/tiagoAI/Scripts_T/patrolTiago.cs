using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolTiago : baseFSMTiago
{
    // Variables
    GameObject[] waypoints;
    public GameObject currentWayPoint;

    public int currentWP;
    public float timer = 3;
    public float debugDistance;


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

        debugDistance = Vector3.Distance(waypoints[currentWP].transform.position, tankAI.transform.position);

        // check if tank has been too long near waypoint
        if (Vector3.Distance(waypoints[currentWP].transform.position, tankAI.transform.position) < 10)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                currentWP = tankAI.GetComponent<tankAITiago>().RandomWaypoint();
                timer = 3;
            }
        }

        // rotates towards WP
        var direction = waypoints[currentWP].transform.position - tankAI.transform.position;
        
        /*  UNUSED WHILE USING NAVMESH --
         *  
        tankAI.transform.rotation = Quaternion.Slerp(tankAI.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        tankAI.transform.Translate(0f, 0f, speed * Time.deltaTime);
        */

        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        tankAgent.SetDestination(waypoints[currentWP].transform.position);

        currentWayPoint = waypoints[currentWP];
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    

}
