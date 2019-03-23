using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyShoot : MonoBehaviour
{
    // Variables
    public GameObject bullet;
    public GameObject turret;

    public bool fireBool;

    public float force;

    // Start is called before the first frame update
    void Start()
    {
        turret = gameObject.transform.Find("Turret").gameObject;
        StartFiring();
    }

    // Update is called once per frame
    void Update()
    {

        /*if (fireBool == true)
            StartFiring();

        else
            StopFiring();
        */
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);

        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * force, ForceMode.Impulse);
        b.transform.SetParent(turret.transform);
    }

    public void StartFiring() //starts firing invoke
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    public void StopFiring() //stops firing invoke
    {
        CancelInvoke("Fire");
    }
}
