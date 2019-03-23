using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject[] Tanks;
    public GameObject winner;
    public int deadTanks;

    int aux;

    // Start is called before the first frame update
    void Start()
    {
        Tanks = GameObject.FindGameObjectsWithTag("tank");
        aux = Tanks.Length - 2;

    }
    // Update is called once per frame
    void Update()
    {
        deadTanks = 0;
        for (int i = 0; i < Tanks.Length; i++)
        {
            
            if (Tanks[i] == null)
            {
                deadTanks++;
            }
            if (deadTanks == aux)
            {
                if (Tanks[i] != null)
                {
                    winner = Tanks[i];
                }
            }
        }
    }
}
