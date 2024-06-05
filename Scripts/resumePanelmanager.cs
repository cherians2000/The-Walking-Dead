using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resumePanelmanager : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused = false;
    public GameObject textToDeactivate;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(textToDeactivate, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true); // Pause the game by setting time scale to 0.
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false); // Resume the game by setting time scale to 1.
        }
    }
   

    public void restart()
    {
        SceneManager.LoadScene("Level");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
