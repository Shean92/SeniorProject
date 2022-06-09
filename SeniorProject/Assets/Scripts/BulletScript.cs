using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public int damage;
    public float destroyTime;
    public bool heatSeeking = false;
    public LayerMask friendlies;
    public Rigidbody2D rb;
    public ParticleSystem bloodSplatter;


    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject, destroyTime);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<HealthManagerScript>() && other.gameObject.layer != friendlies.value)
        {
            other.gameObject.GetComponent<HealthManagerScript>().TakeDamage(damage);
            bloodSplatter.Emit(20);
        }
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }

}
