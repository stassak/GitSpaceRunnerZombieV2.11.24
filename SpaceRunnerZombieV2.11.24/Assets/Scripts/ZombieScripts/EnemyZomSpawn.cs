using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class EnemyZomSpawn : MonoBehaviour
{
    public GameObject zombPrefab;
    private InputAction spawnAction;

    private int spawnPosX = 30;
    private int spawnPosZ = -30;

    // Start is called before the first frame update
     void Start()
     {
        InvokeRepeating("SpawnRandomZom", 2, 2.5f);
     }

    void Awake()
    {
        // Create and configure the InputAction for spawning zombies
     /*   spawnAction = new InputAction(binding: "<Keyboard>/b");
        spawnAction.Enable(); // Enable the action*/
    }

    // Update is called once per frame
    void Update()
    {
      /*  if(spawnAction.WasPerformedThisFrame()) //(Input.GetKeyDown(KeyCode.B))
        {
            SpawnRandomZom();   
        }*/
    }

    void SpawnRandomZom()
    {
        Vector3 spawnPosXZ = new Vector3(Random.Range(30, -30), 0, Random.Range(30, -30));
        Instantiate(zombPrefab, spawnPosXZ, zombPrefab.transform.rotation);
    }
    private void OnDestroy()
    {
        spawnAction.Disable();
    }
}
