using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public bool immortal = false;
    public bool isZombie = false;
    public bool zombiefied = false;

    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !immortal)
        {
            immortal = true;
            Die();
        }
    }

    void Die()
    {
        if (!isZombie)
        {
            Instantiate(zombie, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
