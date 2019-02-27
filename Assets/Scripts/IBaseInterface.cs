using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseInterface 
{
    int GetHealth();
    void SetHealth(int h);
    Transform GetPosition();



    //Methods to the behaviour
    void MoveTo(GameObject target); //Move towards a GameObject
    void Shoot();
    void RandomMove(); //Move into the scene randomly
    GameObject GetNearestTank();
    bool IsSomethingVisible();
    float GetDistanceTo(GameObject target);
    void StopMove();



}
