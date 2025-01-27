using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Scope : MonoBehaviour
{

    private bool isScoped = false;
    InputAction scope;

    public GameObject scopeOverlay;
    public Camera mainCamera;
    public Camera scopedCamera;

    void Start()
    {
        // Initialize the input action for scoping and enable it
        scope = new InputAction("HUDscope", binding: "<mouse>/rightButton");
        scope.Enable();

        // Ensure the scope overlay and scoped camera are initially inactive
        scopeOverlay.SetActive(false);
        scopedCamera.enabled = false;
    }

    void Update()
    {
        // Check if the scope action was triggered (right mouse button clicked)
        if (scope.triggered)
        {
            isScoped = !isScoped;  // Toggle scoping state
            ToggleScope();
        }
    }

    void ToggleScope()
    {
        // Toggle the overlay and camera based on scoping state
        scopeOverlay.SetActive(isScoped);

        if (isScoped)
        {
            mainCamera.enabled = false;
            scopedCamera.enabled = true;
        }
        else
        {
            mainCamera.enabled = true;
            scopedCamera.enabled = false;
        }
    } 
}
