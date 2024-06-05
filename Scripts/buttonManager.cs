using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class buttonManager : MonoBehaviour
{





    public void playButton()
    {
        SceneManager.LoadScene("TimeLineWeek");

    }
    public void exitButton()
    {
        Application.Quit();
    }
}
