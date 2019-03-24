using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BehaviourTank1 : MonoBehaviour, IBaseInterface 
{

    //Variables
    public int health;
    public float speed;
    public float rangeOfVision;
    public Transform fireTransform;
    public float launchForce;
    public Slider aimSlider;
    public Rigidbody shell;
    public Transform tankTurret;

    public GameObject nearestTank;


    private MenuControl menuControl;
    private NavMeshAgent navTank;

    bool isInFront;
    float timeBetweenFires = 0.5f;
    float timeAfterFire;
    int shootableMask;

    bool isDead;

    //For flee
    Transform startTransform;
    float multiplyBy = 5f;
    float nextTurnTime = 2f;



    // Start is called before the first frame update
    void Start()
    {
        menuControl = GameObject.Find("GameController").GetComponent<MenuControl>();
        navTank = this.gameObject.GetComponent<NavMeshAgent>();

        shootableMask = LayerMask.GetMask("Shootable");
        //timeAfterFire = 0f;
        //RunFrom();
    }

    // Update is called once per frame
    void Update()
    {
        nearestTank = GetNearestTank();
        if (nearestTank != null)
        {
           //Quaternion newRotation = Quaternion.LookRotation(nearestTank.transform.position);
           //tankTurret.transform.rotation = Quaternion.Slerp(tankTurret.rotation, newRotation, Time.deltaTime * 3);
            tankTurret.LookAt(nearestTank.transform);
        }



        aimSlider.value = 30f;
        timeAfterFire += Time.deltaTime;

        if(timeAfterFire >= timeBetweenFires)
        {
            Shoot();
        }
       // Shoot();

       // if(Time.time > nextTurnTime)
       // {
       //     RunFrom();
       // }

    }




    //Methods

    public float GetDistanceTo(Transform target)
    {
        return Vector3.Distance(this.transform.position, target.position);
    }

    public int GetHealth()
    {
        return health;
    }

    public GameObject GetNearestTank()
    {
        if(menuControl.allTanks.Count == 0)
        {
            return null;
        }
        float distance = 1000;
        GameObject nearestTank = null;
        foreach(GameObject tank in menuControl.allTanks)
        {
            if(tank == this.gameObject)
            {
                tank.GetComponentInChildren<Renderer>().material.color = Color.blue;
                continue;
            }
            else
            {
                float aux = Vector3.Distance(tank.transform.position, this.transform.position);

                if (aux < distance)
                {
                    distance = aux;
                    nearestTank = tank;
                }
                else
                {
                    tank.GetComponentInChildren<Renderer>().material.color = Color.blue;
                }
            }
            
        }
        if(nearestTank != null) {
            //nearestTank.GetComponent<Renderer>().material.color = Color.black;
            nearestTank.GetComponentInChildren<Renderer>().material.color = Color.black;

          
            
            

            return nearestTank;

        }
        else
        {
            return null;
        }
       
    }

    public Transform GetPosition()
    {
        return this.gameObject.transform;
    }

    public bool IsSomethingVisible()
    {

        //TO DO
        throw new System.NotImplementedException();
    }

    public void MoveTo(Transform target)
    {
        navTank.isStopped = false;
        navTank.destination = target.position;
    }

    public void RandomMove()
    {

        //TO DO
        throw new System.NotImplementedException();
    }

    public void SetHealth(int h)
    {
        health = h;
    }


    public void StopMove()
    {
        navTank.isStopped = true;
    }

    public void Shoot()
    {

       //Ray shootRay;
       //shootRay.origin = fireTransform.position;
       //shootRay.direction = fireTransform.forward;
        RaycastHit hit;



        if (Physics.Raycast(fireTransform.position, fireTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootableMask))
        {
            Debug.DrawRay(fireTransform.position, fireTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("SHOOOT");
            isInFront = true;



            Rigidbody shellInstance = Instantiate(shell, fireTransform.position, Quaternion.identity) as Rigidbody;

            shellInstance.velocity = launchForce * fireTransform.forward;
            //audio
            timeAfterFire = 0f;


        }
        else
        {
            isInFront = false;
            Debug.DrawRay(fireTransform.position, fireTransform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
            //Debug.Log("NOT SHOOTING");
        }
        
        


    }

    public float GetSpeed()
    {

        return speed;
        
        
    }


    public void Death()
    {
       if(health <= 0)
        {
            isDead = true;

            //TO DO BEHAVIOUR, destroy or something
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void RunFrom()
    {
        startTransform = transform;
        //temporarily point the object to look away from the player
        transform.rotation = Quaternion.LookRotation(transform.position - GetNearestTank().transform.position);

        //Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
        // for this if you want variable results) and store it in a new Vector3 called runTo
        Vector3 runTo = transform.position + transform.forward * multiplyBy;
        //Debug.Log("runTo = " + runTo);

        //So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.

        NavMeshHit hit;    // stores the output in a variable called hit

        // 5 is the distance to check, assumes you use default for the NavMesh Layer name
        NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetNavMeshLayerFromName("Default"));
        //Debug.Log("hit = " + hit + " hit.position = " + hit.position);

        // just used for testing - safe to ignore
        nextTurnTime = Time.time + 5;

        // reset the transform back to our start transform
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;

        // And get it to head towards the found NavMesh position
        navTank.SetDestination(hit.position);
    }
}
