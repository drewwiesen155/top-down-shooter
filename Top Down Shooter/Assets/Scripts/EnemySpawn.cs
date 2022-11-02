using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public int enemiesPerWave = 5;
    public Transform enemies;


    void Start()
    {
        enemies = GameObject.FindWithTag("AllEnemies").transform;
    }

    public IEnumerator SpawnEnemies(int wave, GameObject enemyPrefab)
    {
        int numToSpawn = wave * enemiesPerWave;

        for (int i = 0; i < numToSpawn; i++)
        {
            //Debug.Log("Spawning enemy!");
            //ands a radius for the spawn point to randomize positioning of enemy spawns
            Vector2 spawnPoint = new Vector2();
            spawnPoint.x = transform.position.x + Random.Range(-3.5f, 3.5f);
            spawnPoint.y = transform.position.y + Random.Range(-3.5f, 3.5f);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            newEnemy.transform.SetParent(enemies.transform, true);
            yield return new WaitForSeconds(Random.Range(1, 4)); //min Inclusive, max Exclusive
        }
    }
}
