using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class TanksSetup : MonoBehaviour
{


    public GameObject prefabTank;
    public Color playerColor;
    public Transform m_SpawnPoint;



    //private TankMovement m_Movement;
    //private TankShooting m_Shooting;
    // private GameObject m_CanvasGameObject;

    private void Awake()
    {
        
    }

    public void Setup()
    {

        

        MeshRenderer[] renderers = prefabTank.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = playerColor;
        }

        GameObject aux = Instantiate(prefabTank, m_SpawnPoint);
    }

}

