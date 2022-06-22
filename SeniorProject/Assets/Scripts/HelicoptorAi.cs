using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicoptorAi : MonoBehaviour
{
    public GameObject target;
    public Transform shootPosition;
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
        target = GameObject.FindWithTag("Player");
        move.getSpeed(0);
        move.InheretProperties(rotate, rotationSpeed, "Military", targetProximity);
        move.TargetAcquired(true);
        move.SetTarget(target);
    }
    private void Update()
    {
        if (Time.time > chillTime)
        {
            move.getSpeed(moveSpeed);
        }
        rotate.RotateTowardsTarget(target.transform.position, rotationSpeed);
        shootingPoint.RotateTowardsTarget(target.transform.position, rotationSpeed);

        if (Time.time > lastTimeShot)
        {
            lastTimeShot = Time.time + timeBetweenShots;
            shoot.Shoot(shootPosition);
        }
    }
}
