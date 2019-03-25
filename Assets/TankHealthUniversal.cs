using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealthUniversal : MonoBehaviour
{
    // Variables
    public int health;
    public GameObject explosion;
    private AudioSource audioExplosion;
    private ParticleSystem explosionParticles;

    private void Awake()
    {
        explosionParticles = Instantiate(explosion).GetComponent<ParticleSystem>();
        audioExplosion = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (health < 1)
        {
            this.gameObject.SetActive(false);
            ParticleSystem.MainModule mainModule = explosionParticles.main;
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();
            audioExplosion.Play();
            Destroy(this.gameObject, mainModule.duration);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "shell")
        {
            health -= 2;
        }
    }
}
