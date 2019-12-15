using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobaken_Run : MonoBehaviour {
	public Action OnEndMove;
	public float speed = 0.5f;
	public GameObject target;

	Vector3 dir;

	void Update() {
		dir = (transform.position - target.transform.position).normalized;
		if ((target.transform.position - transform.position).sqrMagnitude <= 45.1584) {
			gameObject.SetActive(false);
			OnEndMove?.Invoke();
		}

		transform.position -= dir * speed;
	}
}
