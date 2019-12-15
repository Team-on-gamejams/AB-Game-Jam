using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonWalking : MonoBehaviour
{
    public bool isMoving;
    public float speed = 100f;
    public Animator animator;
    public Vector2 direction;
    public bool flip;

    Rigidbody2D rb2d;
    Vector3 movement;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
            movement = direction * speed;
        else
            movement = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = -direction;
    }

    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        if (
            (movement.x < 0 && transform.localScale.x > 0 && flip == true ) ||
            (movement.x > 0 && transform.localScale.x < 0 && flip == true)
            )
        {
            Vector3 rot = transform.localScale;
            rot.x = -rot.x;
            transform.localScale = rot;
        }
        animator.SetFloat("Forward", movement.y);
        rb2d.MovePosition(transform.position + movement);
    }
}
