using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform Enemies;
    public int enemiesPerWave = 1;
    public int wave;
    private bool waveOver;

    public Text waveCounter; //Need this here to access wave

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        waveOver = true;
        Enemies = GameObject.FindWithTag("AllEnemies").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveOver)
        {
            StartCoroutine(SpawnEnemies());
        }

        waveOver = CheckWaveStatus();
    }

    IEnumerator SpawnEnemies()
    {
        int numToSpawn = wave * enemiesPerWave;
        waveOver = false;

        for(int i = 0; i < numToSpawn; i++) 
        {
            //Debug.Log("Spawning enemy!");
            //ands a radius for the spawn point to randomize positioning of enemy spawns
            Vector2 spawnPoint = new Vector2();
            spawnPoint.x = transform.position.x + Random.Range(-3.5f, 3.5f);
            spawnPoint.y = transform.position.y + Random.Range(-3.5f, 3.5f);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            newEnemy.transform.SetParent(Enemies.transform, true);
            yield return new WaitForSeconds(Random.Range(1, 4)); //min Inclusive, max Exclusive
        }
    }

    private bool CheckWaveStatus()
    {
        //If enemies are still on the map
        if(Enemies.childCount > 0)
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
            if(waveCounter != null) 
            {
                waveCounter.text = ("Wave " + wave);
            }
            

            return true;
        }
    }
}
