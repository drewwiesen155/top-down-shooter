using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject oozePrefab;
    public GameObject wormPrefab;

    [Header("Wave Data")]
    public Transform enemies;
    public int wave;
    private bool waveOver;

    [Header("UI")]
    public Text waveCounter; //Need this here to access wave

    [Header("Bullet Management")]
    //TODO

    EnemySpawn[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        waveOver = true;

        spawnPoints = gameObject.GetComponentsInChildren<EnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waveOver)
        {
            waveOver = false;
            for(int i = 0; i < spawnPoints.Length; i++)
            {   
                //TODO: Implement multiple enemies and varying them in waves;
                if(wave % 5 == 0)
                {

                    StartCoroutine(spawnPoints[i].SpawnEnemies(wave/5, wormPrefab));    //Every 5 Waves there is a worm wave. Starts at 10 worms then incrememnts up
                    //StartCoroutine(spawnPoints[i].SpawnEnemies(wave, oozePrefab));  //Placeholder
                }
                else
                {
                    StartCoroutine(spawnPoints[i].SpawnEnemies(wave, oozePrefab));
                }
                
            }
        }

        waveOver = CheckWaveStatus();
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
