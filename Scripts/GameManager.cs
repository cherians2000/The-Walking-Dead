using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public int killed = 0;
    public static int Pkilled = 0;
    public GameObject mission2;
    public GameObject win;
    public int delay=3;

  
  
    public static GameManager instance;
  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
           
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Debug.Log(Pkilled);
        if (Pkilled >= 3)
        {
            StartCoroutine(won());
        }
    }

    public void IncrementKills()
    {
        killed++;
        UpdateKillsText();
        if (killed == 17)
        {
            StartCoroutine(WinnerCoroutine());
        }
    }

    private void UpdateKillsText()
    {
        if (killsText != null)
        {
            killsText.text =killed.ToString()+" / 17";
        }
       
    }

    private IEnumerator WinnerCoroutine()
    {
        yield return new WaitForSeconds(5f);

        if (mission2 != null)
        {
            mission2.SetActive(true);
            Destroy(mission2,25f);
           
        }
    }
    IEnumerator won()
    {
        yield return new WaitForSeconds(delay);
        win.SetActive(true);
    }

}
