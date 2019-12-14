using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herowalking : MonoBehaviour

{
    private Rigidbody2D rb2D;
    float moveH = 0f, moveV = 0f;
    public float speed = 10f;
    private Rigidbody2D rb2d;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //================================================
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        
        
        float moveVertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Forward", moveVertical);


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        
        rb2d.AddForce(movement * speed);
    }
}
