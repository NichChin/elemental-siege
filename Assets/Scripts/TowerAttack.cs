using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform target; // The enemy to attack
    public float attackSpeed = 1f; // Speed of the Pok�mon's attack
    public float attackRange = 0.01f; // Distance to consider the attack "hit"
    public int attackDamage = 10; // Damage dealt on hit
    public float opacity = 0.5f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.material.color = new Color(1f, 1f, 1f, opacity);
    }

    private void Update()
    {
        if (target != null)
        {
            
            float step = attackSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);

            
            if (Vector2.Distance(transform.position, target.position) < attackRange)
            {
                DealDamage();
                Destroy(gameObject); 
            }
        } else if (target == null)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void DealDamage()
    {
        if (target == null)
        {
            return;
        }
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(attackDamage);
            print(enemy.getHealth());
        }
    }
}
