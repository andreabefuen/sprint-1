using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealthUniversal : MonoBehaviour
{
    // Variables
    public int health;

    public void Update()
    {
        if (health < 1)
        {
            Destroy(this.gameObject);
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
