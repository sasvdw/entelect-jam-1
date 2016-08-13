using UnityEngine;
using System.Collections;

public class InitialVelocity : MonoBehaviour
{
    public float Speed = 10.0f;

	// Use this for initialization
	void Start ()
	{
	    var body = GetComponent<Rigidbody2D>();
	    var rotation = Random.rotation;
	    rotation.x = 0;
	    rotation.y = 0;
        var force = new Vector2(0, Random.value * Speed);
	    var thrust = rotation*force;
        body.AddForce(thrust, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
