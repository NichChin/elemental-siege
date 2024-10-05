using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform target; // The enemy to attack
    public float attackSpeed = 1f; // Speed of the Pokémon's attack
    public float attackRange = 0.01f; // Distance to consider the attack "hit"
    public int attackDamage = 10; // Damage dealt on hit

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
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void DealDamage()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(attackDamage);
            print(enemy.getHealth());
        }
    }
}
