using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryAI : MonoBehaviour
{
    public GameObject target;
    public Transform shootPosition;
    public FOVEnemyScript fov;
    public AiMovementScript move;
    public HealthManagerScript health;
    public ShootingScript shoot;
    public RotateToTarget rotate;
    public RotateToTarget shootingPoint;

    public float rotationSpeed;
    public float moveSpeed;
    public float timeBetweenShots;
    private float lastTimeShot;
    public float targetProximity;
    public float chillTime;

    private void Awake()
    {
        move.InheretProperties(rotate, rotationSpeed, "Military", targetProximity);
        health.isZombie = false;
    }
    private void Update()
    {

        if (Time.time > chillTime)
        {
            move.getSpeed(moveSpeed);
        }

        if (fov.canSeeTarget)
        {
            move.getSpeed(moveSpeed);
            target = fov.target;
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
}
