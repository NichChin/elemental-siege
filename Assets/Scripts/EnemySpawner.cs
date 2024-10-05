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

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }
     public IEnumerator SpawnWaves()
    {
        for (int i = 0; i < wavesPerRound; i++)
        {
            yield return StartCoroutine(SpawnWave());
            yield return new WaitForSeconds(timeBetweenWaves);
            currentWave++;
        }
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log("Wave starting!");
        // some sort of inc to enemies per wave
        int enemiesToSpawn = baseEnemiesPerWave + (currentWave * 2);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2f); // delay between enemy spawns
        }

        Debug.Log("Wave complete!"); 
    }

    private void SpawnEnemy()
    {
        if (enemySpawnPoints.Length == 0) return;

        int randomIndex = UnityEngine.Random.Range(0, enemySpawnPoints.Length);
        Instantiate(enemyPrefab, enemySpawnPoints[randomIndex].position, Quaternion.identity);
    }


}
