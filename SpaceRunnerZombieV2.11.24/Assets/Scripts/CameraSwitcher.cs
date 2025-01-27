using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondCamera;

    void Start()
    {
        // Ensure only the main camera is enabled at the start
        mainCamera.enabled = true;
        secondCamera.enabled = false;
    }

    void Update()
    {
        // Press "C" to switch cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCameras();
        }
    }

    void SwitchCameras()
    {
        // Toggle the enabled state of both cameras
        mainCamera.enabled = !mainCamera.enabled;
        secondCamera.enabled = !secondCamera.enabled;
    }
}
