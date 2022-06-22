using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianAi : MonoBehaviour
{
    public GameObject target;
    public FOVEnemyScript fov;
    public AiMovementScript move;
    public RotateToTarget rotate;

    public float rotationSpeed;
    public float moveSpeed;
    public float targetProximity;
    public float chillTime;

    private void Awake()
    {
        move.InheretProperties(rotate, rotationSpeed, "Civilian", targetProximity);
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
        }
        else
        {
            move.TargetAcquired(false);
        }
    }
}
