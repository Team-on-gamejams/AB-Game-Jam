using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFall : MonoBehaviour {
	public float speed = 100.0f;

	[SerializeField] GameObject[] snows;
	float[] yPos;

	private void Awake() {
		yPos = new float[snows.Length];
		for(byte i = 0; i < snows.Length; ++i) {
			yPos[i] = snows[i].transform.position.y - 800;
		}
	}

	private void Update() {
		for (byte i = 0; i < snows.Length; ++i) {
			yPos[i] -= speed;
			if (snows[i].transform.position.y <= -1938)
				yPos[i] = 1978;
			snows[i].transform.position = new Vector3(snows[i].transform.position.x, yPos[i]);
		}
	}
}
