using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private LayerMask enemyMask;
    
    [Header("Attribute")]
    [SerializeField] private float targetingRange;

    private Transform target;
    private Quaternion targetRotation;

    private void FindTarget(){
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, targetingRange, enemyMask);
        print(hits.Length);
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

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
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

        if (!IsTargetInRange()) {
            target = null;
        }

    }
}
