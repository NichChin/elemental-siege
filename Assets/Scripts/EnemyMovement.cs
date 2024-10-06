using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private int damage = 20;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }
        
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            
            if (pathIndex >= LevelManager.main.path.Length)
            {
                // reached the end
                EnemySpawner.onEnemyDestroy.Invoke();
                LevelManager.main.DecreaseHealth(damage);
                Destroy(gameObject);
                return;
            } else 
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }    

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
    
}
