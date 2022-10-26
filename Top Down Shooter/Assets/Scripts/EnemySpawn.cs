using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesPerWave = 5;
    private int wave;
    private bool waveOver;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        waveOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveOver)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        int numToSpawn = wave * enemiesPerWave;
        waveOver = false;

        for(int i = 0; i < enemiesPerWave; i++) 
        {
            Debug.Log("Spawning enemy!");
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}
