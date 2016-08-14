using UnityEngine;
using System.Collections;

public class LaserBoltMovement : MonoBehaviour {

    public float speed = 10.0f;

    Rigidbody2D body;

    void Start() {
        body = GetComponent<Rigidbody2D>();

        body.AddForce(new Vector2(0, speed));
    }

    void Update() {
        if (Input.GetButton("Fire1")) {

        }
    }
}
