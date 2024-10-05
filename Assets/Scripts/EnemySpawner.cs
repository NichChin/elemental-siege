using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] enemySpawnPoints;
    [SerializeField] private int wavesPerRound = 3;
    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private int baseEnemiesPerWave = 5;

    private int currentWave = 0;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }
     public IEnumerator SpawnWaves()
    {
        for (int i = 0; i < wavesPerRound; i++)
        {
            yield return StartCoroutine(SpawnWave());
            yield return new WaitUntil(() => AllEnemiesDefeatedOrReachedEnd());
            yield return new WaitForSeconds(timeBetweenWaves);
            currentWave++;
        }
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log("Wave starting!");
        spawnedEnemies.Clear();

        // some sort of inc to enemies per wave
        int enemiesToSpawn = baseEnemiesPerWave + (currentWave * 2);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = new GameObject($"EnemyPlaceholder_{i}");
            spawnedEnemies.Add(enemy);
        }

        for (int i = 0; i < enemiesToSpawn; i++)
            {
                InstantiateEnemy(i);
                yield return new WaitForSeconds(2f); // delay between enemy spawns
            }

        Debug.Log("Wave complete!"); 
    }

    private void InstantiateEnemy(int index)
    {
        if (enemySpawnPoints.Length == 0) return;

        int randomIndex = UnityEngine.Random.Range(0, enemySpawnPoints.Length);
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoints[randomIndex].position, Quaternion.identity);
        spawnedEnemies[index] = enemy; // replace placeholder with actual enemy
        Debug.Log($"Enemy {enemy.GetInstanceID()} spawned! Total enemies: {spawnedEnemies.Count}");
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        Debug.Log("Trying to remove enemy. Current enemies: " + spawnedEnemies.Count);
    
    if (spawnedEnemies.Contains(enemy))
    {
        spawnedEnemies.Remove(enemy);
        Debug.Log($"Enemy {enemy.GetInstanceID()} removed from list! Total enemies left: {spawnedEnemies.Count}");
        Destroy(enemy);
        Debug.Log("Enemy destroyed!");
    }
    else
    {
        Debug.LogError($"Enemy {enemy.GetInstanceID()} not found in list!");
    }
    }

    private bool AllEnemiesDefeatedOrReachedEnd()
    {
        Debug.Log("asdf");
        spawnedEnemies.RemoveAll(enemy => enemy == null || enemy.GetComponent<Enemy>().HasReachedEnd);
        return spawnedEnemies.Count == 0;
    }


}
