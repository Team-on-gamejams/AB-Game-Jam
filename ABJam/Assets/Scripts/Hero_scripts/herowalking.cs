using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class herowalking : MonoBehaviour

{
    private Rigidbody2D rb2D;
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
        
        animator.SetFloat("Right", moveHorizontal);
        animator.SetFloat("Left", moveHorizontal);

        if (
            (moveHorizontal < 0 && transform.localScale.x > 0) ||
            (moveHorizontal > 0 && transform.localScale.x < 0)
            )
        {
            Vector3 rot = transform.localScale;
            rot.x = -rot.x;
            transform.localScale = rot;
        }

        float moveVertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Forward", moveVertical);
        animator.SetFloat("Backward", moveVertical);





        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        
        rb2d.AddForce(movement * speed);
    }

   

}
