using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksSetup : MonoBehaviour
{

    public GameObject prefabTank;
    public Color playerColor;
    public Transform m_SpawnPoint;
    [HideInInspector] public int m_Wins;


    //private TankMovement m_Movement;
    //private TankShooting m_Shooting;
   // private GameObject m_CanvasGameObject;


    public void Setup()
    {

        

        MeshRenderer[] renderers = prefabTank.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = playerColor;
        }
    }

}

