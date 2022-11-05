using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    //public int enemiesPerWave = 5;
    public Transform enemies;


    void Start()
    {
        enemies = GameObject.FindWithTag("AllEnemies").transform;
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
            //ands a radius for the spawn point to randomize positioning of enemy spawns
            Vector2 spawnPoint = new Vector2();
            spawnPoint.x = transform.position.x + Random.Range(-2.5f, 2.5f);
            spawnPoint.y = transform.position.y + Random.Range(-2.5f, 2.5f);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            newEnemy.transform.SetParent(enemies.transform, true);
    }
}
