using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    const int maxEnemies = 5;
    public int currentEnemies = 0;
    [SerializeField] private GameObject enemy;
    private int timesSpawned;

	// Use this for initialization
	public void SpawnEnemy()
    {
        Instantiate(enemy);
        enemy.transform.position = transform.position;
        currentEnemies++;
        timesSpawned++;     
    }

    public void EnemyKilled()
    {
        currentEnemies--;
    }

    private void Update()
    {
        if (currentEnemies == 0)
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnEnemy();
            }
        }
        //if (currentEnemies = maxEnemies) 
        //{
        //    SpawnEnemy();
        //}
    }
}
