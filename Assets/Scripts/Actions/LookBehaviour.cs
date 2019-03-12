using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookBehaviour : MonoBehaviour
{

    public Transform tankTurret;
    public Transform fireTransform;

    public GameObject tankToSee;

    int shootableMask;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
       // anim.SetBool("chase", true);

        shootableMask = LayerMask.GetMask("Shootable");
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    void Look()
    {
        RaycastHit hit;

        if(Physics.Raycast(fireTransform.position, fireTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shootableMask))
        {
            Debug.DrawRay(fireTransform.position, fireTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            tankTurret.LookAt(hit.transform);
            tankToSee = hit.transform.gameObject;
            anim.SetBool("chase", true);
            Debug.Log("Ha visto algo");
        }

    }
}
