using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float enemySpawnZ = 14.0f;
    private float spawnRangeX = 18.0f;
    private float zPowerupRange = 6.0f;
    private float spawnY = 0.65f;

    private float powerupSpawnTime = 4.0f;
    private float enemySpawnTime = 2.5f;
    private float startDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRandomEnemy();
        SpawnPowerup();
    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        int randomIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(randomX, spawnY, enemySpawnZ);
        
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, spawnY, randomZ);
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }

 }
