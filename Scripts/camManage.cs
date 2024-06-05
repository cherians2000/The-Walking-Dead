using UnityEngine;
using Cinemachine;

public class camManage : MonoBehaviour
{
    public CinemachineVirtualCameraBase[] cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == currentCameraIndex);
        }
    }

    private void Update()
    {
        // Example: Switch to the next camera on the "C" key press.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Increment the index to switch to the next camera.
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Activate the new camera.
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }
}
