using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BodyGravity : MonoBehaviour
{
    private Rigidbody2D body;
    private Dictionary<BodyGravity, BodyGravity> bodies = new Dictionary<BodyGravity, BodyGravity>();
    private const float G = 0.9f;

    // Use this for initialization
	void Start ()
	{
	    this.body = GetComponent<Rigidbody2D>();

        this.bodies = GameObject.FindObjectsOfType<BodyGravity>().ToDictionary(x => x);

	    foreach (var body in bodies)
	    {
	        if (body.Value.bodies.ContainsKey(this))
	        {
	            continue;
	        }

            body.Value.bodies.Add(this, this);
	    }
    }

    // Update is called once per frame
    void Update () {

    }

    void FixedUpdate()
    {
        foreach (var body in this.bodies)
        {
            if (body.Value == this)
            {
                continue;
            }

            var heading = body.Value.GetHeadingToBody(this.body);
            var forceAtHeight = body.Value.GetGravityAtHeight(this.body);
            var force = heading.normalized * forceAtHeight;
            this.body.AddForce(force);
        }
    }

    void OnDestroy()
    {
        foreach (var body in this.bodies)
        {
            if (body.Value == this)
            {
                continue;
            }

            body.Value.RemoveFromSimulation(this);
        }
    }

    private void RemoveFromSimulation(BodyGravity bodyToDestroy)
    {
        this.bodies.Remove(bodyToDestroy);
    }

    private float GetGravityAtHeight(Rigidbody2D body)
    {
        var heading = this.GetHeadingToBody(body);
        var r = heading.magnitude / 50;
        if (r < 0.5f)
        {
            return 0.0f;
        }
        return G * ((this.body.mass * body.mass) / (r * r));
    }

    private Vector2 GetHeadingToBody(Rigidbody2D body)
    {
        return this.body.position - body.position;
    }
}
