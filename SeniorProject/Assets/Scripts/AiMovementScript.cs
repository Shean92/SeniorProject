using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovementScript : MonoBehaviour
{
    private GameObject target;
    private bool targeting;
    private float speed;
    private string creatureType;
    private float rotationSpeed;
    public Rigidbody2D rb;
    public Vector2 movePosition;
    private RotateToTarget rotate;
    public float wanderTime;
    private float lastTimeWandered;
    public float distance;

    // Wander Script General to all Ai
    void FixedUpdate()
    {
        if (targeting)
        {
            switch (creatureType)
            {
                case "Military":
                    MilitaryMove();
                    break;
                case "Zombie":
                    ZombieMove();
                    break;
                case "Civilian":
                    CivilianMove();
                    break;

            }
        }
        else
        {
            Wander();
        };
        if (rb.velocity.magnitude > speed)
        {
            //Include nav mesh A*
            //When the player runs into the enemy, the rotation and movement get all messed up for some reason.
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
    // Zombie Movement
    // Civilian Run script

    public void InheretProperties(RotateToTarget rotate, float speed, float rotationSpeed, string creatureType)
    {
        this.rotate = rotate;
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
        this.creatureType = creatureType;
    }
    private void Wander()
    {
        if (Vector3.Distance(rb.transform.position, movePosition) <= 1)
        {
            movePosition.x = Random.Range(rb.position.x - distance, rb.position.x + distance);
            movePosition.y = Random.Range(rb.position.y - distance, rb.position.y + distance);
            lastTimeWandered = Time.time + wanderTime;
        }
        else
        {
            rotate.RotateTowardsTarget(movePosition, rotationSpeed);
        }
        MoveForward();
    }

    private void MilitaryMove()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            MoveForward();
        }
        if (Vector3.Distance(transform.position, target.transform.position) < 5)
        {
            MoveBackward();
        }
    }

    private void ZombieMove()
    {

    }

    private void CivilianMove()
    {

    }

    public void TargetAcquired(bool targeting)
    {
        this.targeting = targeting;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    private void MoveForward()
    {
        rb.transform.position += rb.transform.up * speed * Time.deltaTime;
        //use a nav mesh
        //follow player past walls to check last known location.
    }

    private void MoveBackward()
    {
        rb.transform.position -= rb.transform.up * speed * Time.deltaTime;
    }
}
