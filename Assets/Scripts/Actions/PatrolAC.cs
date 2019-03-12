using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAC : MonoBehaviour
{
    public GameObject waypoint;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    void Patrol()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
