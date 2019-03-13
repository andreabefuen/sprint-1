using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public float distanceShoot;

    public GameObject tankToSee;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = totalHealth;
    }

    public void TakeDamage(float amount)
    {
        // Reduce current health by the amount of damage done.
        currentHealth -= amount;

        // Change the UI elements appropriately.
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
       // if (currentHealth <= 0f && !m_Dead)
       // {
       //     OnDeath();
       // }
    }

    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        healthSlider.value = totalHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        fillImageHealth.color = Color.Lerp(zeroHealthColor, fullHeathColor, currentHealth / totalHealth);
    }

}
