using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZStepRoar : MonoBehaviour
{
    public AudioClip[] roarSound;

    private AudioSource audioSourceZom;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceZom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoarSound()
    {
        audioSourceZom.PlayOneShot(roarSound[Random.Range(0, roarSound.Length)]);
    }
}
