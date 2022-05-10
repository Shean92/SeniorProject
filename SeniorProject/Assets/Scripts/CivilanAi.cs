using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilanAi : MonoBehaviour
{
    float amount;
    public GameObject player;
    Vector3 direction;
    Vector3 runPoint;
    Vector3 walkPoint;
    float speed;

    void Start()
    {
        runPoint = transform.position;
        walkPoint = transform.position;
    }

    void Update()
    {
        amount = ((player.transform.position) - (transform.position)).magnitude;
        direction = ((player.transform.position) - (transform.position)).normalized;
        if (amount > 100)
        { // if player is more then 100 units away
            normal(); // normal waypoint system or what you want
        }
        else if (amount > 20)
        { // player is beetwen 20 and 100 units away
            chased(); // animal has chased the player
        }
        else
        { // player is less then 20 unity away
            run();
        }
    }

    void normal()
    {
        if ((walkPoint - transform.position).magnitude < 5)
        {
            // get new point here
        }
        else
        {
            // moving script here
        }
    }

    void chased()
    {
        transform.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));
        transform.position += -direction * speed * Time.deltaTime;
    }

    void run()
    {
        if ((runPoint - transform.position).magnitude < 5)
        {

        }
        else
        {
            // moving script here
        }
    }
}