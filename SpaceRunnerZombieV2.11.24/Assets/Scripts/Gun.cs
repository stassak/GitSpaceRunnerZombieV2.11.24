using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;



public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    InputAction shoot;
    public float shootRange = 30;
    public float impactForce = 150;

    public int zombieDamage = 20;

    public int fireRate = 10;
    public float nextTimeToFire = 0;

    public ParticleSystem muzzleFlush;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.AddBinding("<GAmepad>/");

        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {


        bool isShooting = shoot.ReadValue<float>() == 1;

        if (isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }
    }
    private void Fire()
    {
        AudioManager.instance.Play("Shoot");

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.position, fpsCam.forward,out hit, shootRange ))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Zombie zombie = hit.transform.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.TakeDamage(zombieDamage);
                return; // return impact effect (blood)
            }


            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            Destroy(impact, 4);

        }
    }
}
