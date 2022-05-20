using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovementScript : MonoBehaviour
{
    private GameObject target;
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
        if (target)
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
            // Can't get smooth movement from the enemies
            rb.MovePosition(movePosition + rotate.direction * speed * Time.fixedDeltaTime);
        };
    }
    // Zombie Movement
    // Civilian Run script
    // Military Maintain distance

    public void InheretProperties(RotateToTarget rotate, float speed, float rotationSpeed, string creatureType)
    {
        this.rotate = rotate;
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
        this.creatureType = creatureType;
    }
    private void Wander()
    {

        if (Time.time > lastTimeWandered)
        {
            movePosition.x = Random.Range(rb.position.x - distance, rb.position.x + distance);
            movePosition.y = Random.Range(rb.position.y - distance, rb.position.y + distance);
            lastTimeWandered = Time.time + wanderTime;
        }
        rotate.RotateTowardsTarget(movePosition, rotationSpeed);
    }

    private void MilitaryMove()
    {

    }

    private void ZombieMove()
    {

    }

    private void CivilianMove()
    {

    }

    public void TargetAcquired(GameObject target)
    {
        this.target = target;
    }
}
