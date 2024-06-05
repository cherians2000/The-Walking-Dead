using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    public Text messageText;
    public float displayDuration = 2.0f; // Adjust the duration as needed
    private float displayTimer;

    private void Start()
    {
        messageText.text = ""; // Initially, no message is displayed
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        displayTimer = displayDuration;
    }

    private void Update()
    {
        if (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
            if (displayTimer <= 0)
            {
                messageText.text = ""; // Clear the message after the display duration
            }
        }
    }
}
