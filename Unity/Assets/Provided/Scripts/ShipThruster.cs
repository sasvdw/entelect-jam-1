using UnityEngine;
using System.Collections;

public class ShipThruster : MonoBehaviour
{
    public float Speed = 10.0f;

    private Rigidbody2D body;
    private Vector2 force;

    // Use this for initialization
	void Start ()
	{
	    this.body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var input = Input.GetAxis("Vertical");
	    var thrust = input > 0 ? input : 0;

        this.force = new Vector2(0, thrust * Speed);
	}

    void FixedUpdate()
    {
        var rot = Quaternion.Euler(0, 0, this.body.rotation);
        Vector2 force = rot * this.force;
        this.body.AddForce(force);
    }
}
