using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyTank : MonoBehaviour
{
    // Variables
    public GameObject[] waypoints;
    public GameObject dummy;

    public float speed;
    public float accuracy;
    public float rotSpeed;

    public int currentWP;
    public int hitCount;

    // Start is called before the first frame update
    void Start()
    {
        dummy = this.gameObject;
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0) return;

        if (Vector3.Distance(waypoints[currentWP].transform.position, dummy.transform.position) < accuracy)
        {
            currentWP = ChangeWaypoint();
        }

        // rotates towards WP
        var direction = waypoints[currentWP].transform.position - dummy.transform.position;

        dummy.transform.rotation = Quaternion.Slerp(dummy.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

        dummy.transform.Translate(0f, 0f, speed * Time.deltaTime);
    }

    public int ChangeWaypoint()
    {
        int waypointInt = Random.Range(0, 3);
        return waypointInt;
    }

    public void ChangeSpeed()
    {

    }

    public void Timer()
    {
        InvokeRepeating("ChangeDirection", 2f, 5f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        hitCount++;
        Debug.Log("i got hit " + hitCount + "times");
    }

}
