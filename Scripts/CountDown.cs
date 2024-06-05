using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countDown;
    public int delay = 2;
    void Start()
    {
        StartCoroutine(CountdownStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CountdownStart()
    {
        for(int i = 10; i >= 0; i--)
        {
            countDown.text=i.ToString();
            yield return new WaitForSeconds(delay);
        }
    }

}
