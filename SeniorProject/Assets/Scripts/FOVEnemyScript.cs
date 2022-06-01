using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVEnemyScript : MonoBehaviour
{
    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    private GameObject target;
    private float distanceToTarget;

    public MilitaryAI militaryAI;

    public bool CanSeePlayer { get; private set; }

    private void Awake()
    {
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            //What I need to do is compare the distance between each object in FoV and pick the one that is the closest.
            for (int i = 0; i < rangeCheck.Length; i++)
            {
                //get current distance, check if last object was further or not, if further then get current object.
                if(i == 0)
                {
                    target = rangeCheck[0].gameObject;
                }
                else {
                    distanceToTarget = Vector2.Distance(transform.position, rangeCheck[i].transform.position);
                
                    if(distanceToTarget <  Vector2.Distance(transform.position, target.transform.position))
                    {
                        target = rangeCheck[i].gameObject;
                    }
                }
            }
            
            Vector2 directionToTarget = (target.transform.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                {
                    CanSeePlayer = true;
                    GetComponent<MilitaryAI>().TargetFound(target);
                }
                else
                    CanSeePlayer = false;
            }
            else
                CanSeePlayer = false;
        }
        else if (CanSeePlayer)
            CanSeePlayer = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

        if (CanSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, militaryAI.target.transform.position);
        }
    }

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
