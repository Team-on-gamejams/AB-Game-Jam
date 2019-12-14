using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMover : MonoBehaviour {
    [SerializeField] float speed = 1.0f;
    [SerializeField]  float amount = 1.0f; 

    void Update() {
        transform.position += new Vector3(Mathf.Sin(Time.time * speed) * amount, 0);
    }

}
