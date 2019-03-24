using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radarLongTiago : MonoBehaviour
{
    // Variables
    public GameObject targetTank;

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
        if (other.gameObject.tag == "tank")
        {
            if (targetTank == null)
            {
                targetTank = other.gameObject;
                Debug.Log("i hit a tank");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetTank)
            targetTank = null;
    }

    public GameObject GetTarget()
    {
        return targetTank;
    }

}
