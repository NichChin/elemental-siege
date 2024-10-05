using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer m_SpriteRenderer;
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject attackPrefab;

    [Header("Attribute")]
    [SerializeField] private float targetingRange;
    // bullets per second
    [SerializeField] private float bps = 1f;

    private Transform target;
    private Quaternion targetRotation;
    private float timeUntilFire; 

    private void FindTarget(){
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, targetingRange, enemyMask);
        if (hits.Length > 0) {
            target = hits[0].transform;
        } 

    }

    private void RotateToTarget()
    {
        float angle = Mathf.Atan2((target.position.y - transform.position.y), (target.position.x - transform.position.x)) * Mathf.Rad2Deg;

        targetRotation = Quaternion.Euler(new Vector3(0,0,angle));

        if (targetRotation.eulerAngles.z >= 90 && targetRotation.eulerAngles.z <= 270) {
            m_SpriteRenderer.flipX = true;
        } else {
            m_SpriteRenderer.flipX = false;
        }
    }

    private bool IsTargetInRange()
    {
        return Vector2.Distance(transform.position, target.position) <= targetingRange;
    }

    private bool IsTargetAlive()
    {
        Enemy enemy = target.parent.GetComponent<Enemy>();
        return enemy.getHealth() > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    private void Attack()
    {
        GameObject towerAttack = Instantiate(attackPrefab, transform.position, Quaternion.identity);
        TowerAttack attackScript = towerAttack.GetComponent<TowerAttack>();
        attackScript.SetTarget(target);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            FindTarget();
            return;
        }
        RotateToTarget();

        if (!IsTargetInRange() || !IsTargetAlive()) {
            target = null;
        } else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bps)
            {
                Attack();
                timeUntilFire = 0f;
            }
        }

    }
}
