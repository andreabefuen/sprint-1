using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiguelTankAI : MonoBehaviour
{
    Animator anim;
    //public GameObject player;
    public GameObject bullet;
    public GameObject turret;
    public GameObject turretLeft;
    public GameObject turretRight;

    public GameObject enemy;
    public GameObject enemyToAttack;
    public GameObject[] enemies;

    public int life = 10;

    //public GameObject GetPlayer()
    //{
    //    return player;
    //}

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 1000);

        GameObject bLeft = Instantiate(bullet, turretLeft.transform.position, turretLeft.transform.rotation);
        bLeft.GetComponent<Rigidbody>().AddForce(turretLeft.transform.forward * 900);

        GameObject bRight = Instantiate(bullet, turretRight.transform.position, turretRight.transform.rotation);
        bRight.GetComponent<Rigidbody>().AddForce(turretRight.transform.forward * 900);

        //GameObject bb = Instantiate(bullet, (turret.transform.position) + new Vector3(-1.0f, 0.0f, 1.0f), (turret.transform.rotation) * Quaternion.Euler(0, 0, 0));
        //bb.GetComponent<Rigidbody>().AddForce(direction.forward * 500);
    }



    public GameObject LookForClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("tank");

        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(enemies[i].transform.position, currentPosition);
            if (distance < minDistance)
            {
                if (enemies[i] != this.gameObject)
                {
                    minDistance = distance;
                    enemy = enemies[i];
                }
                
            }
        }
        return enemy;
    }


    public void StopFiring()
    {
        CancelInvoke("Fire");
    }



    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 1.5f);
    }



	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	


	// Update is called once per frame
	void Update ()
    {
        enemyToAttack = GetComponent<MiguelTankAI>().LookForClosestEnemy();
        anim.SetFloat("distance", Vector3.Distance(transform.position, enemyToAttack.transform.position));


	}




    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "shell")
        {
            life -= 1;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }*/
}
