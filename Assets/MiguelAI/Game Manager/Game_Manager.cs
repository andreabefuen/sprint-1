using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject[] Tanks;
    public GameObject winner;
    int deadTanks;

    // Start is called before the first frame update
    void Start()
    {
        Tanks = GameObject.FindGameObjectsWithTag("tank");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Tanks.Length; i++)
        {
            if (Tanks[i] == null)
            {
                deadTanks++;
            }
            if (deadTanks == 2)
            {
                if (Tanks[i] != null)
                {
                    winner = Tanks[i];
                }
            }
        }
    }
}
