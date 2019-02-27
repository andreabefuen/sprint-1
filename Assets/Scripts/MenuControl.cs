using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject tankPrefab;
    public List<GameObject> allTanks;

    public void CreateNewTank()
    {
       GameObject newTank =  GameObject.Instantiate(tankPrefab, new Vector3(tankPrefab.transform.position.x, 0, tankPrefab.transform.position.z), Quaternion.identity);
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
            tank.GetComponent<BehaviourTank1>().MoveTo(tank.GetComponent<BehaviourTank1>().GetNearestTank());
           
          
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
