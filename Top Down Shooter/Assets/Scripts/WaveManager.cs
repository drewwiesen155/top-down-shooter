using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{

    public GameObject oozePrefab;
    public GameObject wormPrefab;
    public Transform enemies;
    public int wave;
    private bool waveOver;

    public Text waveCounter; //Need this here to access wave

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
                if(wave % 2 == 1)
                {
                    StartCoroutine(spawnPoints[i].SpawnEnemies(wave, wormPrefab));
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
