﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformspawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] moving_Platform;
    public GameObject breakable_platform;

    public GameObject enemy1prefab;
    public GameObject enemy2prefab;

    public float platform_spawn_timer = 2f;
    private float current_platform_spawn_timer;
    private int platform_spawn_count = 0;
    public float enemy_spawn_timer = 3f;

    private float current_enemy_spawn_timer;
    private int enemy_spawn_count = 0;
  
    public float min_X=-16.5f,max_x=16.5f;
   
    void Start()
    {
        current_platform_spawn_timer = platform_spawn_timer;
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
        SpawnEnemy();
    }
    void SpawnPlatforms()
    {
        current_platform_spawn_timer += Time.deltaTime;
        if(current_platform_spawn_timer>=platform_spawn_timer)
        {
            platform_spawn_count++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_x);
            GameObject newPlatform = null;
            if(platform_spawn_count<2)
            {
                newPlatform= Instantiate(platformPrefab, temp, Quaternion.identity);

            }
            else if(platform_spawn_count==2)
            {
                if(Random.Range(0,2)>0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(moving_Platform[Random.Range(0, moving_Platform.Length)],temp,Quaternion.identity);

                }

            }
            else if(platform_spawn_count == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }

            }
            else if (platform_spawn_count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakable_platform, temp, Quaternion.identity);
                }
                platform_spawn_count = 0;
            }
            newPlatform.transform.parent = transform;
            current_platform_spawn_timer = 0f;
        }//this spawns the platforms
        

    }
    void SpawnEnemy()
    {
        current_enemy_spawn_timer += Time.deltaTime;
        if (current_enemy_spawn_timer >= enemy_spawn_timer)
        {
            enemy_spawn_count++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_x);
            GameObject newEnemy = null;
            if (enemy_spawn_count < 2)
            {
                newEnemy = Instantiate(enemy1prefab, temp, Quaternion.identity);

            }
            else if (enemy_spawn_count == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newEnemy = Instantiate(enemy2prefab, temp, Quaternion.identity);
                }


            }
            newEnemy.transform.parent = transform;
            current_enemy_spawn_timer = 0f;
        }
        

    }
}
