using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class herowalking : MonoBehaviour {
	public float speed;
	public Animator animator;

	Rigidbody2D rb2d;
	Vector3 movement;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update() {
		movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		movement = movement.normalized * speed;
	}

	void FixedUpdate() {
		animator.SetFloat("Right", movement.x);
		animator.SetFloat("Left", movement.x);

		if (
			(movement.x < 0 && transform.localScale.x > 0) ||
			(movement.x > 0 && transform.localScale.x < 0)
			) {
			Vector3 rot = transform.localScale;
			rot.x = -rot.x;
			transform.localScale = rot;
		}

		animator.SetFloat("Forward", movement.y);
		animator.SetFloat("Backward", movement.y);

		rb2d.MovePosition(transform.position + movement);
	}
}
