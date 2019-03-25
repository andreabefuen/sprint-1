using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public GameObject[] Tanks;
    public GameObject winner;
    public int deadTanks;

    public Text winnerText;

    public GameObject childCanvas;

    int aux;

    private void Update()
    {
        Tanks = GameObject.FindGameObjectsWithTag("tank");

        if (Tanks.Length <= 1)
        {
            winner = Tanks[0];

            winnerText.text = Tanks[0].transform.name;
            childCanvas.SetActive(true);
        }
    }

    public void PlayAgainButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
