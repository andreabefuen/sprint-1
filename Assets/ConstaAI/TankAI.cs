using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    public GameObject tank;
    public GameObject bullet;
    public GameObject turret;
    public GameObject checkSomething;
    public Rigidbody shell;
   
    public float totalHealth;
    public float currentHealth;
    public float powerLaunch;

    void Fire()
    {
        GameObject bFire = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        bFire.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }


    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        currentHealth = totalHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "shell")
        {
            TakeDamage(2.5f);
        }
    }

    void TakeDamage ( float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Debug.Log("Is dead");
            Destroy(this.gameObject, 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tank")
        {
            Debug.Log("found u");
            checkSomething = other.gameObject;
            anim.SetTrigger("goToChase");
        }
    }
}
