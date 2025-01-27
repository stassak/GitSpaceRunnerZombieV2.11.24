using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;

    public int damagePlayerAmount = 10;

    public float radius = 2;
  //  public AudioSource audioSource;
  

    //public AudioClip zombieSound;

    private void Start()
    {
      /*  audioSource = GetComponent<AudioSource>();
        audioSource.clip = zombieSound;*/
    }

    /*public void Roar()
    {
        if (audioSource != null && zombieSound != null)
        {
            audioSource.PlayOneShot(zombieSound);
        }
    }*/

    //  public Transform animator;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            // play death anmation
            animator.SetTrigger("die");
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            //play get hit animation
            animator.SetTrigger("damage");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damagePlayerAmount);
            }
        }

        //from GDT Damage and death
      /*  Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearByObject in colliders)
        {
            if (nearByObject.tag == "Player")
            {
                PlayerManager.TakeDamage(damagePlayerAmount);
            }
        }*/
    }
}
