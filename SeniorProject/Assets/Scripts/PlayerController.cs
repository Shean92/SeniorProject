using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 moveDirection;
    private Vector2 mousePos;
    private float callBrainsTime;
    private float lastTimeCalledBrains;
    public float deteriorate;
    public float deteriorateAmount;
    private float lastTimeDeteriorated;
    public HealthManagerScript playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<HealthManagerScript>();
    }
    private void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Time.time > callBrainsTime + lastTimeCalledBrains)
        {
            callBrainsTime = Random.Range(10, 20);
            lastTimeCalledBrains = Time.time;
            FindObjectOfType<AudioManager>().Play("Zombie Brains");
        }

        if (Time.time > deteriorate + lastTimeDeteriorated)
        {
            playerHealth.TakeDamage(deteriorateAmount);
            lastTimeDeteriorated = Time.time;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}