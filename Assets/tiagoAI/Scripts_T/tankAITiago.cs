using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankAITiago : MonoBehaviour
{
    // Variables
    Animator anim;
    
    public GameObject tankAI;
    public GameObject targetTank;
    public GameObject turret;
    public GameObject bullet;
    public GameObject radarLong;
    public GameObject radarClose;
    public GameObject avoidable;
    public GameObject shellHolder;

    public float speed = 10;
    public float distance;
    public float force = 25;
    public float lookSpeed = 8;
    public int health = 10;

    public Vector3 currentPos, lastPos, projDirection, lastDirection, evadeVector; //vars related to projectile evasion

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        tankAI = this.gameObject;

        // getting child objects
        turret = tankAI.transform.Find("TankRenderers/TankTurret").gameObject;
        radarLong = tankAI.transform.Find("RadarLong").gameObject;
        radarClose = tankAI.transform.Find("RadarClose").gameObject;
        shellHolder = new GameObject("shellHolder");
    }

    // Update is called once per frame
    void Update()
    {
        // gets target tank from radarLong child and checks its distance, using it to regulate the force of the shell needs to hit the target
        targetTank = radarLong.GetComponent<radarLongTiago>().GetTarget();

        // behaviour methods
        SetAnimatorDistance();
        AdjustForceAndLookSpeed();
        Death();

        // gets incoming projectiles so that the AI may evade them - THIS COULD BE A METHOD, BUT FOR ORGANISATION I LIKE IT HERE
        avoidable = radarClose.GetComponent<radarCloseTiago>().GetProjectile();

        if (avoidable != null)
        {
            if (avoidable.transform.parent.gameObject != shellHolder)
            {
                currentPos = avoidable.transform.position;
                if (currentPos != lastPos) //get projectile direction
                {
                    projDirection = currentPos - lastPos;
                    var lastDirection = projDirection;
                }

                lastPos = currentPos;

                if (projDirection != lastDirection)
                {
                    evadeVector = Vector3.Cross(projDirection, Vector3.up).normalized;

                    var evadePoint = evadeVector + gameObject.transform.position;

                    evadePoint.y = 0;
                    var direction = evadePoint - this.transform.position;
                    gameObject.transform.Translate(evadePoint.normalized * (speed / 2) * Time.deltaTime);
                    //tankAI.transform.rotation = Quaternion.Slerp(tankAI.transform.rotation, Quaternion.LookRotation(direction), 3 * Time.deltaTime);
                }
            }
        }
    }

    /////// END OF UPDATE ///////
     /////// END OF UPDATE ///////
     /////// END OF UPDATE ///////

    /* /// Collision Detection
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "shell")
        {
            health -= 3;
        }
    }*/


    ///////////////////////////
    ///  Behaviour Methods  ///
    ///                     ///


    public int RandomWaypoint() //gives random int to be used on the waypoint array
    {
        int waypointInt = Random.Range(0, 3);
        return waypointInt;
    }

    private void SetAnimatorDistance() //sets the animator parameter "distance"
    {
        if (targetTank != null)
            distance = Vector3.Distance(transform.position, targetTank.transform.position);

        if (targetTank != null)
            anim.SetFloat("distance", distance);

        else
            anim.SetFloat("distance", 100);
    }

    private void AdjustForceAndLookSpeed() //adjusts force and lookSpeed values depending on distance
    {
        if (distance < 6)
        {
            force = 6.5f;
        }

        if (distance < 10 && distance > 5)
        {
            force = 10;
            lookSpeed = 5;
        }
            
        if (distance > 9 && distance < 15)
        {
            force = 25;
            lookSpeed = 7;
        }

        if (distance > 14)
        {
            force = 40;
            lookSpeed = 8;
        }
    }

    void Death()
    {
        if (health < 1)
            GameObject.Destroy(this.gameObject);
    }

    ///////////////////////////
    ///   Getter Methods    ///
    ///                     ///

    public float GetSpeed() //returns tank speed
    {
        return speed;
    }

    public float GetTargetDistance() //returns distance from target tank
    {
        return distance;
    }

    public float GetLookSpeed() //returns look speed so that it has more accuracy depending on distance
    {
        return lookSpeed;
    }

    public GameObject GetTarget() //returns target 
    {
        return targetTank;
    }

    public GameObject GetTank() //returns the game object with this script
    {
        return tankAI;
    }

    public GameObject GetTurret() //returns the child object Turret
    {
        return turret;
    }

    public Vector3 GetShellDirection()
    {
        return projDirection;
    }
    

    ///  Fire Methods  ///
    void Fire() //when called, instatiates bullets with a given impulse force
    {
        GameObject b = Instantiate(bullet, turret.transform.Find("Turret").gameObject.transform.position, turret.transform.rotation);
        
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * force, ForceMode.Impulse);
        b.transform.SetParent(shellHolder.transform); //set parent as child object ShellHolder
    }

    public void StopFiring() //stops firing invoke
    {
        CancelInvoke("Fire");
    }

    public void StartFiring() //starts firing invoke
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    public int GetHealth ()
    {
        return health;
    }

} //end of class

    

