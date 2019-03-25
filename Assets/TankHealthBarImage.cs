using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealthBarImage : MonoBehaviour
{
    // Variables
    public GameObject parentCanvas;
    public GameObject parentTank;

    public Image healthBar;

    public Color maximumHealth = Color.green;
    public Color minimumHealth = Color.red;

    int currentHealth;
    int maxHealth;

    public int tankID;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = this.GetComponent<Image>();
        parentCanvas = healthBar.transform.parent.gameObject;
        parentTank = parentCanvas.transform.parent.gameObject;

        maxHealth = parentTank.GetComponent<TankHealthUniversal>().GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = parentTank.GetComponent<TankHealthUniversal>().GetHealth();

        currentHealth = parentTank.GetComponent<TankHealthUniversal>().GetHealth();
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (float)currentHealth / (float)maxHealth, 0.1f);
        healthBar.color = Color.Lerp(minimumHealth, maximumHealth, (float)currentHealth / (float)maxHealth);
    }
}
