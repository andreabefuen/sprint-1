using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TankStats : MonoBehaviour
{
    public Color colorTank;
    public float totalHealth;
    public float speed;
    public float rangeOfVision;
    public float strength;
    public Transform fireTransform;
    public float launchForce;
    public Slider aimSlider;
    public Slider healthSlider;
    public Image fillImageHealth;
    public Color zeroHealthColor = Color.red;
    public Color fullHeathColor = Color.green;
    public Rigidbody shell;
    public Transform tankTurret;
    public GameObject explosionPrefab;
    private ParticleSystem explosionParticles;

    public float timeBetweenFire = 1f;

    public float distanceShoot;

    public GameObject tankToSee;

    private NavMeshAgent navMeshAgent;

    public float currentHealth;
    private bool isDead = false;
    Animator anim;

    private void Awake()
    {

        currentHealth = totalHealth;

        navMeshAgent = this.GetComponent<NavMeshAgent>();

        navMeshAgent.speed = speed;

        anim = this.GetComponent<Animator>();


        MeshRenderer[] renderers = this.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = colorTank;
        }



    }

    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        currentHealth = totalHealth;
        isDead = false;

        // Update the health slider's value and color.
        
    }


    public void StopMovement()
    {
        navMeshAgent.isStopped = true;
    }

    public void ContinueMovement()
    {
        navMeshAgent.isStopped = false;
    }



    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "shell")
        {
            TakeDamage(2.5f);
            Debug.Log("AUCH");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tank")
        {
            Debug.Log("otro tanque");
            tankToSee = other.gameObject;
            anim.SetBool("chase", true);


        }
    }

}
