using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject panel;
    bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        isActive = panel.gameObject.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.gameObject.SetActive(!isActive);
            isActive = !isActive;
            if (isActive)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

        } 
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene("MenuScene");

    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
        isActive = false;
    }
}
