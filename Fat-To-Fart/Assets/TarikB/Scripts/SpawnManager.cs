using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    


    public Transform cam;

    private float delayTime = 1.0f;
    private float spawnInterval = 3f;



    void Start()
    {

        InvokeRepeating("SpawnRandomAnimalZ", delayTime, spawnInterval);

        cam = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {

    }

    private void SpawnRandomAnimalZ()
    {
        if (LevelController.Current == null || !LevelController.Current.gameActive)
        {
            return;
        }
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPoz = new Vector3(Random.Range(-8, 10), 11.5f, cam.transform.position.z+15);
        Instantiate(animalPrefabs[animalIndex], spawnPoz, animalPrefabs[animalIndex].transform.rotation);
    }
}
