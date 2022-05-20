using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public bool immortal = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0 && !immortal)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
