using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{

    private Animator _doorAnimator; // ref to the anim component on the door
    // Start is called before the first frame update
    void Start()
    {
        _doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            _doorAnimator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Automatically close the door when the Plaayer leaves the trigger area
        if (other.CompareTag("Player"))
        {
            _doorAnimator.SetTrigger("Closed");
        }
    }
}
