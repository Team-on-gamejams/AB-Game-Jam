using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class herowalking : MonoBehaviour {
	static public bool isCanMove;

	public float speed;
	public Animator animator;
	public DemonDialogUI demonDialogUI;

	Rigidbody2D rb2d;
	Vector3 movement;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
		isCanMove = true;
	}

	void Update() {
		if (isCanMove) {
#if UNITY_ANDROID || UNITY_IOS
			movement = new Vector3(UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxisRaw("Horizontal"), UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxisRaw("Vertical"));
#else
			movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#endif
			movement = movement.normalized * speed;
		}
		else {
			movement = Vector3.zero;
		}
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

	void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "DeamonDialog") {
			DemonDialog demonDialog = collision.GetComponent<DemonDialog>();
			if (!demonDialog.isGifted) {
				demonDialogUI.demon = demonDialog;
				demonDialogUI.ShowDialog();
			}
		}	
	}
}
