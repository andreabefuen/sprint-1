using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radarCloseTiago : MonoBehaviour
{
    // Variables
    public GameObject avoidable;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "shell")
        {
            Debug.Log("i detect a shell");
            avoidable = other.gameObject;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "shell")
        {
            Debug.Log("i detect a shell");
            avoidable = other.gameObject;
        }
    }

    public GameObject GetProjectile()
    {
        return avoidable;
    }

}
