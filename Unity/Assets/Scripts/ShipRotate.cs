using UnityEngine;

public class ShipRotate : MonoBehaviour
{
    public float Speed = 10.0f;
    private Rigidbody2D body;
    private float torque;

    // Use this for initialization
	void Start ()
	{
	    this.torque = 0;
	    this.body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.torque = Input.GetAxis("Horizontal") * Speed;
	}

    void FixedUpdate()
    {
        body.AddTorque(-torque);
    }
}
