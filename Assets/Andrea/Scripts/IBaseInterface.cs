using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseInterface 
{


    float GetSpeed();
    void SetSpeed(float newSpeed);

    

    int GetHealth();
    void SetHealth(int h);
    Transform GetPosition();



    //Methods to the behaviour
    void MoveTo(Transform target); //Move towards a GameObject
    void Shoot(); //The tank only shoot when the other tank is in front of the actual tank
    void RandomMove(); //Move into the scene randomly
    GameObject GetNearestTank();
    bool IsSomethingVisible();
    float GetDistanceTo(Transform target);
    void StopMove(); //disable the navmesh

    void Death(); //When health is below 0, you are dead


}
