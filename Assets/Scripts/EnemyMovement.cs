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
    private Quaternion targetRotation;
    private SpriteRenderer m_SpriteRenderer;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
        
    private void RotateToTarget()
    {
        float angle = Mathf.Atan2((target.position.y - transform.position.y), (target.position.x - transform.position.x)) * Mathf.Rad2Deg;

        targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (targetRotation.eulerAngles.z >= 90 && targetRotation.eulerAngles.z <= 270)
        {
            m_SpriteRenderer.flipX = true;
        }
        else
        {
            m_SpriteRenderer.flipX = false;
        }
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
                RotateToTarget();
            }
        }
    }    

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
    
}
