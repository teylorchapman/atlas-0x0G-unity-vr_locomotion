using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombies;
    public Transform[] spawnPos;
    private float timePassed;
    private float pauseSpawn;
    public float spawnSpeed = 5.0f;

    void Start()
    {
        pauseSpawn = spawnSpeed;
    }

    void Update()
    {
        timePassed = Time.realtimeSinceStartup;
        if (Mathf.Round(timePassed) % 10 == 0 && pauseSpawn < 0)
        {
            SpawnNewZombie();
            pauseSpawn = spawnSpeed;
        }
        pauseSpawn -= 0.0138f;
    }

    void SpawnNewZombie()
    {
        new WaitForSeconds(UnityEngine.Random.Range(0, 5));
        GameObject zombie = Instantiate(zombies, spawnPos[UnityEngine.Random.Range(0, 20)]);
        zombie.transform.localPosition = Vector3.zero;
    }
}
