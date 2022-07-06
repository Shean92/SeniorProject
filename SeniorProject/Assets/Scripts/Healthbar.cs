using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public HealthManagerScript playerHealth;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManagerScript>();
    }
    
    void Update()
    {
        slider.maxValue = playerHealth.maxHealth;
        slider.value = playerHealth.currentHealth;
    }
}
