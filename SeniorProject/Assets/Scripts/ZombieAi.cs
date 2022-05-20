using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{

    private enum State
    {
        Roaming,
        ChaseTarget,
    }

    private EnemyPathfindingMovement pathfindingMovement;
    private Vector3 startingPosition;
    private Vector3 raomPosition;
    private State state;

    public static Vecto3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private void Awake()
    {
        pathfindingMovement = GetComponent<EnemyPathfindingMovement>();
        state = State.Roaming;
    }

    private void Start()
    {
        startingPosition = transform.position;
        GetRoamingPosition = GetRoamingPosition();
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                pathfindingMovement.MoveToTimer(roamPosition);

                float reachedPositionDistance = if;
                if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance {
                    // Reached Roam Position
                    roamPosition = GetRoamingPosition();
                }

                FindTarget();
                break;
            case State.ChaseTarget:
                pathfindingMovement.MoveToTimer(Human.Instance.GetPosition());
                break;
        }

    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDir() * Random.Range(10f, 70f);
    }

    private void FindTarget()
    {
        float targetRange = 50f;
        if (Vector3.Distance(transform.position, Human.Instance.GetPosition()) < targetRange)
        {
            // Human within target range
            state = State.ChaseTarget;
        }
    }
}

