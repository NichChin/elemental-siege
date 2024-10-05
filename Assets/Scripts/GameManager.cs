using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [SerializeField] private EnemySpawner enemySpawner;
    private bool gameActive = false;

    private void Awake()
    {
        // only want one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gameActive = true;
        // later add setup + rounds
        enemySpawner.SpawnWaves();
        Debug.Log("Game Started!");
    }

    public void EndGame()
    {
        gameActive = false;
        Debug.Log("Game Over!");
    }

    void Update()
    {
        
    }
}
