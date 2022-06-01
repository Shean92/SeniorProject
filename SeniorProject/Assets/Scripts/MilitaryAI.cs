using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryAI : MonoBehaviour
{
    public GameObject target;
    public Transform shootPosition;
    public FOVEnemyScript fov;
    public AiMovementScript move;
    public ShootingScript shoot;
    public RotateToTarget rotate;
    public RotateToTarget shootingPoint;

    public float rotationSpeed;
    public float moveSpeed;
    public float timeBetweenShots;
    public float lastTimeShot;

    private void Awake()
    {
        //target = GameObject.FindGameObjectWithTag("Player");
        move.InheretProperties(rotate, moveSpeed, rotationSpeed, "Military");
    }
    // change player for any Target with Zombie layer
    private void Update()
    {
        if (fov.CanSeePlayer)
        {
            move.TargetAcquired(true);
            move.SetTarget(target);
            rotate.RotateTowardsTarget(target.transform.position, rotationSpeed);
            shootingPoint.RotateTowardsTarget(target.transform.position, rotationSpeed);

            if (Time.time > lastTimeShot)
            {
                lastTimeShot = Time.time + timeBetweenShots;
                shoot.Shoot(shootPosition);
            }
        }
        else
        {
            move.TargetAcquired(false);
        }
    }

    public void TargetFound(GameObject target)
    {
        this.target = target;
    }
}
