﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MiguelAIBaseFSM
{

    GameObject[] waypoints;
    int currentWP;



    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = Random.Range(0, 4);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWP].transform.position, MiguelAI.transform.position) < accuracy)
        {
            currentWP = Random.Range(0, 4);

            //currentWP++;
            //if (currentWP >= waypoints.Length)
            //{
            //    currentWP = 0;
            //}
        }

        //rotate towards character
        var direction = waypoints[currentWP].transform.position - MiguelAI.transform.position;
        MiguelAI.transform.rotation = Quaternion.Slerp(MiguelAI.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        MiguelAI.transform.Translate(0, 0, Time.deltaTime * speed);
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}


}