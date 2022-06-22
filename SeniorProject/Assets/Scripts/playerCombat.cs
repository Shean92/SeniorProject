using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public float attackDamage;
    public ParticleSystem bloodSplatter;
    public float attackRate;
    public float nextAttackTime;
    public bool canShoot;
    private float nextShootTime;
    public float shootRate;
    public Transform shootPosition;
    public ShootingScript shoot;
    public HealthManagerScript playerHealth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }

        if (Input.GetMouseButton(1) && Time.time >= nextShootTime && canShoot)
        {
            shoot.Shoot(shootPosition);
            nextShootTime = Time.time + 1f / shootRate;
        }

        //if we choose to not use the mouse 
        // if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        // {
        //     Attack();
        //     nextAttackTime = Time.time + 1f / attackRate;
        // }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HealthManagerScript>().TakeDamage(attackDamage);
            HealthManagerScript enemyHealth = enemy.GetComponent<HealthManagerScript>();
            enemyHealth.TakeDamage(attackDamage);
            playerHealth.TakeDamage(-attackDamage);
            enemyHealth.zombiefied = true;
            bloodSplatter.Emit(20);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
