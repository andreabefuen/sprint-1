using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BehaviourTank1 : MonoBehaviour, IBaseInterface 
{

    //Variables
    public int health;
    public float rangeOfVision;

    public GameObject nearestTank;


    private MenuControl menuControl;
    private NavMeshAgent navTank;


    // Start is called before the first frame update
    void Start()
    {
        menuControl = GameObject.Find("GameController").GetComponent<MenuControl>();
        navTank = this.gameObject.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        nearestTank = GetNearestTank();
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

    public void Shot()
    {
        throw new System.NotImplementedException();
    }

    public void StopMove()
    {
        navTank.isStopped = true;
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }
}
