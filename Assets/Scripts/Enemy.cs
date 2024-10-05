using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    private float health = 100f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
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

    void Update()
    {
    
    }
}
