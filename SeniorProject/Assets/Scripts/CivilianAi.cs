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

    private void Awake()
    {
        move.InheretProperties(rotate, moveSpeed, rotationSpeed, "Civilian");
    }
    private void Update()
    {
        if (fov.canSeeTarget)
        {
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
