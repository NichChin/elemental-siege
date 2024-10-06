using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    [SerializeField] float health = 10f;
    [SerializeField] public int manaReward = 10; // change amt depending on enemy later on?
    [SerializeField] public int enemyReward = 10; // change amt depending on enemy later on?

    private bool isDestroyed = false;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0 && !isDestroyed)
        {
            LevelManager.main.IncreaseMana(manaReward);
            LevelManager.main.IncreaseScore(enemyReward);
            EnemySpawner.onEnemyDestroy.Invoke();
            isDestroyed = true;

            Destroy(gameObject);
        }
    }

    public float getHealth()
    {
        return health;
    }
    void Start()
    {
     animator = GetComponent<Animator>();   
    }
}
