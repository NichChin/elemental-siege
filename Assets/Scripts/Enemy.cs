using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool HasReachedEnd {get; private set;} = false;
    private bool isRemovedFromList = false;
    private Animator animator;
    private EnemySpawner enemySpawner;
    void Start()
    {
        animator = GetComponent<Animator>();   
        enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogError("EnemySpawner not found!");
        }
    }

    void Update()
    {
        
    }

    public void ReachEnd()
    {
        if (HasReachedEnd) return;

        HasReachedEnd = true;
        Debug.Log("Enemy reached end!");
        enemySpawner.RemoveEnemyFromList(gameObject);

        // also do smtn about losing main tower health, etc.
    }

    public void RemoveFromList()
    {
        if (!isRemovedFromList)
        {
            enemySpawner.RemoveEnemyFromList(gameObject);
            isRemovedFromList = true;
        }
    }

    private void OnDestroy()
    {
        RemoveFromList(); // Ensure enemy is removed from list when destroyed
    }
}
