using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public int numberEnemies = 5;

    public Transform spawnLocation;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTimer <= 0) { 
            //generate enemies
            if (enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity); //spawn first enemy in our list
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0; //end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }
    
    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; //give a fixed time between each enemies
        waveTimer = waveDuration; //waveDuration is read Only
    }

    public void GenerateEnemies()
    {
        //create a temporary list of enemies to generate 
        //in a loob of grab a random enemy 
        // see if we can afford it 
        //if we can, add it to our list, and reduce the cost? -> repeat... -> if we have no point left, leave the loop
        List<GameObject> generateEnemies = new List<GameObject>();
        
        //add loai enemy 1, co bao nhieu enemy, tao bay nhieu vong for.
        for (int i =0; i < numberEnemies; i++)
        {
            generateEnemies.Add(enemies[0].enemyPrefab);
        }
        for (int i = 0; i < numberEnemies; i++)
        {
            generateEnemies.Add(enemies[1].enemyPrefab);
        }


        enemiesToSpawn.Clear();
        enemiesToSpawn = generateEnemies;
    }
}

[System.Serializable]
public class Enemy
{
    
    public GameObject enemyPrefab; 
}
