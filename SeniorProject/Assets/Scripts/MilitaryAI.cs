using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryAI : MonoBehaviour
{
    public GameObject playerRef;
    public FOVEnemyScript fov;

    public float rotationSpeed;

    private void Awake()
    {
        fov = GetComponent<FOVEnemyScript>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (fov.CanSeePlayer)
        {
            RotateTowardsTarget();
        }
    }

    private void RotateTowardsTarget()
    {
        var offset = -90f;
        Vector2 direction = playerRef.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
