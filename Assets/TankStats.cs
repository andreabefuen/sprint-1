using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TankStats : MonoBehaviour
{

    public float totalHealth;
    public float speed;
    public float rangeOfVision;
    public Transform fireTransform;
    public float launchForce;
    public Slider aimSlider;
    public Slider healthSlider;
    public Image fillImageHealth;
    public Color zeroHealthColor;
    public Color fullHeathColor;
    public Rigidbody shell;
    public Transform tankTurret;
    public GameObject explosionPrefab;
    private ParticleSystem explosionParticles;

    public float distanceShoot;

    public GameObject tankToSee;

    private NavMeshAgent navMeshAgent;

    private float currentHealth;
    private bool isDead = false;

    private void Awake()
    {

        
        currentHealth = totalHealth;

        navMeshAgent = this.GetComponent<NavMeshAgent>();

        navMeshAgent.speed = speed;
        



        // Instantiate the explosion prefab and get a reference to the particle system on it.
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();

        // Get a reference to the audio source on the instantiated prefab.
        //m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        // Disable the prefab so it can be activated when it's required.
        explosionParticles.gameObject.SetActive(false);

    }

    public void TakeDamage(float amount)
    {
        // Reduce current health by the amount of damage done.
        currentHealth -= amount;

        // Change the UI elements appropriately.
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (currentHealth <= 0f && !isDead)
        {
            OnDeath();
        }
    }

    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        healthSlider.value = totalHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        fillImageHealth.color = Color.Lerp(zeroHealthColor, fullHeathColor, currentHealth / totalHealth);
    }

    private void OnDeath()
    {
        // Set the flag so that this function is only called once.
        isDead = true;

        // Move the instantiated explosion prefab to the tank's position and turn it on.
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        explosionParticles.Play();

        // Play the tank explosion sound effect.
        // m_ExplosionAudio.Play();


        Destroy(this.gameObject, 0.5f);
        // Turn the tank off.
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tank")
        {
            Debug.Log("otro tanque");
            tankToSee = other.gameObject;
        }
    }

}
