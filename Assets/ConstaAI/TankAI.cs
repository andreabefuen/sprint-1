using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject bullet;
    public GameObject turret;

    public float totalHealth;
    public float currentHealth;

    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
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

    // Update is called once per frame
    void Update()
    {


       
        anim.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
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
}
