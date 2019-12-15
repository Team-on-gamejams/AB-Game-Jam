using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobaken_Run : MonoBehaviour
{
    public float speed = 0.5f;
    public Animator animator;
    public GameObject objectGetting;
    Rigidbody2D rb2d;
    Vector3 movement;
    
    void Start()
    {
            
    }

    
    void Update()
    {
        movement = objectGetting.transform.position;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(transform.position + movement);
    }
}
