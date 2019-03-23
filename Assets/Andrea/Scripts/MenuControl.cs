using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject tankPrefab;
    public List<GameObject> allTanks;
    public Color colorTank1;
    public Color colorTank2;
    public Color colorTank3;
    public Color colorTank4;




    public void CreateNewTank()
    {
        GameObject newTank = GameObject.Instantiate(tankPrefab, new Vector3(Random.Range(-40, 40), 0, Random.Range(-40, 40)), Quaternion.identity);
        MeshRenderer[] renderers = newTank.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = colorTank1;
        }
       
        allTanks.Add(newTank);
    }


    public void MoveToNearest()
    {
        if(allTanks.Count == 0)
        {
            return;
        }
        foreach(GameObject tank in allTanks)
        {
            tank.GetComponent<BehaviourTank1>().MoveTo(tank.GetComponent<BehaviourTank1>().GetNearestTank().transform);
           
          
        }
    }
    public void StopMovement()
    {
        if (allTanks.Count == 0)
        {
            return;
        }
        foreach (GameObject tank in allTanks)
        {
            tank.GetComponent<BehaviourTank1>().StopMove();


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
