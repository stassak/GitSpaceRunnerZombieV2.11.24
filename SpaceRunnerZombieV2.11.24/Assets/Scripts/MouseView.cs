using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseView : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;

    // Two camera references
    public Camera camera1;
    public Camera camera2;

    private float xRotation = 0f;
    private bool isCamera1Active = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Set camera1 as active and camera2 as inactive initially
        if (camera1 != null) camera1.enabled = true;
        if (camera2 != null) camera2.enabled = false;
    }

    void Update()
    {
        float mouseX = 0;
        float mouseY = 0;

        // Switch cameras on key press (example: "C" key)
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            ToggleCamera();
        }

        // Reading from mouse input if available
        if (Mouse.current != null)
        {
            mouseX = Mouse.current.delta.ReadValue().x * mouseSensitivity * Time.deltaTime;
            mouseY = Mouse.current.delta.ReadValue().y * mouseSensitivity * Time.deltaTime;
        }

        // Reading from gamepad input if available
        if (Gamepad.current != null)
        {
            mouseX = Gamepad.current.rightStick.ReadValue().x * mouseSensitivity * Time.deltaTime;
            mouseY = Gamepad.current.rightStick.ReadValue().y * mouseSensitivity * Time.deltaTime;
        }

        // Adjust xRotation and clamp it
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Method to toggle between cameras
    void ToggleCamera()
    {
        isCamera1Active = !isCamera1Active;

        if (camera1 != null) camera1.enabled = isCamera1Active;
        if (camera2 != null) camera2.enabled = !isCamera1Active;
    }
}
