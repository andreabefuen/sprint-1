using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealthFlash : MonoBehaviour
{
    // Variables
    public Image healthBar;

    public Color startColor = Color.white;
    public Color endColor = Color.gray;

    public AnimationCurve flashCurve;

    public int currentHealth;
    int lastHealth;
    int maxHealth;

    float flashTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.parent.Find("HealthImage").gameObject.GetComponent<Image>();

        currentHealth = this.transform.parent.transform.parent.GetComponent<tankAITiago>().GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth != lastHealth)
        {

        }

        lastHealth = currentHealth;
    }
}
