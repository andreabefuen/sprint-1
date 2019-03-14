using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject tankPrefab;
    public List<GameObject> allTanks;

    public TanksSetup[] tanks;

    public void CreateNewTank()
    {
       GameObject newTank =  GameObject.Instantiate(tankPrefab, new Vector3(Random.Range(-40,40), 0, Random.Range(-40, 40)), Quaternion.identity);
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
