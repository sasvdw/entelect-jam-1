using UnityEngine;
using System.Collections;

public class HorizontalMovementBehaviour : MonoBehaviour {

    public float speed = 10.0f;

    Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * speed;

        body.AddForce(new Vector2(x, 0));
	}
}
