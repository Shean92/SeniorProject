using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public bool immortal;
    public bool isZombie;
    public bool zombiefied;
    public bool isVehicle;
    public ParticleSystem explosion;
    public ParticleSystem smoke;
    public GameObject zombie;
    private Upgrades upgrades;
    public int brains;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        upgrades = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>();
    }

    private void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
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
        if (!isZombie && !isVehicle)
        {
            Instantiate(zombie, gameObject.transform.position, gameObject.transform.rotation);
            upgrades.AddBrains(brains);
        }
        if (isVehicle)
        {
            explosion.Emit(100);
            smoke.Emit(100);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 1);
        }
        if (gameObject != null && !isVehicle)
        {
            Destroy(gameObject);
        }
    }
}
