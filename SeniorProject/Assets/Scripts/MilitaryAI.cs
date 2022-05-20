using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryAI : MonoBehaviour
{
    public GameObject playerRef;
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
        playerRef = GameObject.FindGameObjectWithTag("Player");
        move.InheretProperties(rotate, moveSpeed, rotationSpeed, "Military");
    }
    // change player for any Target with Zombie layer
    private void Update()
    {
        if (fov.CanSeePlayer)
        {
            move.TargetAcquired(playerRef);
            rotate.RotateTowardsTarget(playerRef.transform.position, rotationSpeed);
            shootingPoint.RotateTowardsTarget(playerRef.transform.position, rotationSpeed);

            if (Time.time > lastTimeShot)
            {
                lastTimeShot = Time.time + timeBetweenShots;
                shoot.Shoot(shootPosition);
            }
        }
        else
        {
            move.TargetAcquired(null);
        }
    }
}
