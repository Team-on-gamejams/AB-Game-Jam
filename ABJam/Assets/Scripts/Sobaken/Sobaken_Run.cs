using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobaken_Run : MonoBehaviour {
	public float speed = 0.5f;
	public GameObject objectGetting;

	Vector3 dir;

	void Awake() {
		dir = (objectGetting.transform.position - transform.position).normalized * speed;
	}

	void Update() {
		if ((objectGetting.transform.position - transform.position).sqrMagnitude <= 45.1584)
			enabled = false;

		transform.Translate(dir);
	}
}
