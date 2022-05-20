using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    public void Shoot(Transform shootPosition)
    {
        Instantiate(bullet, shootPosition.position, shootPosition.rotation);
    }
}
