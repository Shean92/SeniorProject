using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public int brainsAmount;
    private int level = 1;
    private HealthManagerScript playerHealth;
    private playerCombat playerCombat;
    private ParticleSystem levelUp;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthManagerScript>();
        playerCombat = player.GetComponent<playerCombat>();
        levelUp = player.transform.Find("Level Up").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (brainsAmount >= Mathf.Pow(level, 2))
        {
            LevelUp();
        }
        if (level > 3)
        {
            //PowerUp
            playerCombat.canShoot = true;
        }
    }
    public void AddBrains(int brains)
    {
        brainsAmount += brains;
    }

    private void LevelUp()
    {
        FindObjectOfType<AudioManager>().Play("Level Up");
        levelUp.Emit(100);
        level++;
        playerHealth.maxHealth++;
        playerCombat.attackDamage += .2f;
    }



}
