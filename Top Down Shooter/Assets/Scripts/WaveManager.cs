using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject oozePrefab;
    public GameObject wormPrefab;
    public GameObject tankOozePrefab;

    [Header("Enemy Spawn Rates")]
    public float tankOozeSpawnChance;

    [Header("Enemy Spawn Wave Thresholds")]
    public int tankOozeFirstWave;

    //Spawn Flags
    private bool tankOozeSpawn;

    [Header("Wave Data")]
    public Transform enemies;
    private bool waveOver;
    private int enemiesPerWave = 10;
    private int enemiesToSpawn;
    
    [HideInInspector]
    public int wave;

    [Header("UI")]
    public Text waveCounter; //Need this here to access wave

    [Header("Bullet Management")]
    //TODO

    EnemySpawn[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        wave = 3;
        waveOver = true;

        spawnPoints = gameObject.GetComponentsInChildren<EnemySpawn>();

        SetSpawnFlags();
    }

    // Update is called once per frame
    void Update()
    {
        if (waveOver)
        {
            SetSpawnFlags();
            StartCoroutine(SpawnWave());
        }

        waveOver = CheckWaveStatus();
    }

    //Spawns all enemies for a wave;
    IEnumerator SpawnWave()
    {
        //Random rng = new Random();
        //Randomize spawn location

        waveOver = false;
        int spawnPointIndex;
        float spawnChance = 0;
        enemiesToSpawn = wave * enemiesPerWave;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);

            //Debug.Log("Spawning Enemy at spawn point " + spawnPointIndex);

            //Every 5 waves is a wave of just worms
            if(wave % 5 == 0)
            {
                for(int j = 0; j < enemiesToSpawn / 3; j++)
                {
                    spawnPoints[spawnPointIndex].SpawnEnemy(wormPrefab);
                    yield return new WaitForSeconds(Random.Range(0.5f, 2f));

                    spawnPointIndex = Random.Range(0, spawnPoints.Length);      //needs this bc its in its own loop
                }

                break;
            }
            else
            {
                //chance of spawning tank ooze
                spawnChance = Random.Range(0.0f, 1.0f);
                
                if(tankOozeSpawn && spawnChance <= tankOozeSpawnChance)
                {
                    Debug.Log("TANK SPAWNING!");
                    spawnPoints[spawnPointIndex].SpawnEnemy(tankOozePrefab);
                }
                    
                else
                    spawnPoints[spawnPointIndex].SpawnEnemy(oozePrefab);

            }
            

            // [ , )
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }

    private void SetSpawnFlags()
    {
        if (!tankOozeSpawn && wave >= tankOozeFirstWave)
            tankOozeSpawn = true;
    }

    private bool CheckWaveStatus()
    {
        //If enemies are still on the map
        if (enemies.childCount > 0)
        {
            //Wave is still ongoing
            return false;
        }
        else
        {
            //Wave is over
            Debug.Log("Wave " + wave + " is over!");
            wave++;
            Debug.Log("Starting Wave " + wave);

            //Since this script is on each spawner, only one will have a reference to the UI to update the wave counter
            if (waveCounter != null)
            {
                waveCounter.text = ("Wave " + wave);
            }


            return true;
        }
    }
}
