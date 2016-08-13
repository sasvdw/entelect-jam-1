using UnityEngine;

public class InitialRotation : MonoBehaviour
{
    public float Speed = 10.0f;

    // Use this for initialization
	void Start ()
    {
        var body = GetComponent<Rigidbody2D>();
	    var torque = Speed*Random.value;
        body.AddTorque(torque, ForceMode2D.Impulse);
    } 
	
	// Update is called once per frame
	void Update () {
	
	}
}