using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;

    public float attackDamage = 1;

    public ParticleSystem bloodSplatter;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        if (hitEnemies != null)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy != null && enemy.tag != "Bullet")
                {
                    HealthManagerScript enemyHealth = enemy.GetComponent<HealthManagerScript>();
                    enemyHealth.TakeDamage(attackDamage);
                    enemyHealth.zombiefied = true;
                    bloodSplatter.Emit(20);
                }
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
