using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BehaviourTank1 : MonoBehaviour, IBaseInterface 
{

    //Variables
    public int health;
    public float rangeOfVision;
    public Transform fireTransform;
    public float launchForce;
    public Slider aimSlider;
    public Rigidbody shell;

    public GameObject nearestTank;


    private MenuControl menuControl;
    private NavMeshAgent navTank;

    bool isInFront;
    float timeBetweenFires = 0.5f;
    float timeAfterFire;
    int shootableMask;


    // Start is called before the first frame update
    void Start()
    {
        menuControl = GameObject.Find("GameController").GetComponent<MenuControl>();
        navTank = this.gameObject.GetComponent<NavMeshAgent>();

        shootableMask = LayerMask.GetMask("Shootable");
        //timeAfterFire = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        nearestTank = GetNearestTank();

        aimSlider.value = 30f;
        timeAfterFire += Time.deltaTime;

        if(timeAfterFire >= timeBetweenFires)
        {
            Shoot();
        }
       // Shoot();

    }




    //Methods

    public float GetDistanceTo(GameObject target)
    {
        return Vector3.Distance(this.transform.position, target.transform.position);
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
        throw new System.NotImplementedException();
    }

    public void MoveTo(GameObject target)
    {
        navTank.isStopped = false;
        navTank.destination = target.transform.position;
    }

    public void RandomMove()
    {
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
            Debug.Log("SHOOOT");
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
}
