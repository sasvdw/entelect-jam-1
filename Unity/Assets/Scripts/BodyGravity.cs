using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BodyGravity : MonoBehaviour
{
    public Dictionary<BodyGravity, float> ForceAppliedToBodies { get { return this.forceAppliedToBodies; } } 

    private Rigidbody2D rigidbody2D;
    private readonly HashSet<BodyGravity> bodies = new HashSet<BodyGravity>();
    private readonly Dictionary<BodyGravity, float> forceAppliedToBodies = new Dictionary<BodyGravity, float>(); 
    private const float G = 0.9f;

    // Use this for initialization
	void Start ()
	{
	    this.rigidbody2D = GetComponent<Rigidbody2D>();

        var bodies = GameObject.FindObjectsOfType<BodyGravity>();

	    foreach (var body in bodies)
	    {
	        this.AddBody(body);
	    }
    }

    // Update is called once per frame
    void Update () {

    }

    void FixedUpdate()
    {
        ApplyGravityFromOtherBodies();
    }

    private void ApplyGravityFromOtherBodies()
    {
        foreach (var body in this.bodies)
        {
            var heading = body.GetHeadingToBody(this.rigidbody2D);
            body.forceAppliedToBodies[this] = body.GetGravityAtHeight(this.rigidbody2D);
            var force = heading.normalized*body.forceAppliedToBodies[this];
            this.rigidbody2D.AddForce(force);
        }
    }

    void OnDestroy()
    {
        foreach (var body in this.bodies)
        {
            body.RemoveFromSimulation(this);
        }
    }

    private void AddBody(BodyGravity bodyToAdd)
    {
        if (bodyToAdd == this || this.bodies.Contains(bodyToAdd))
        {
            return;
        }

        this.bodies.Add(bodyToAdd);
        this.forceAppliedToBodies.Add(bodyToAdd, 0.0f);

        bodyToAdd.AddBody(this);
    }

    private void RemoveFromSimulation(BodyGravity bodyToDestroy)
    {
        if (!this.bodies.Contains(bodyToDestroy))
        {
            return;
        }

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
        return G * ((this.rigidbody2D.mass * body.mass) / (r * r));
    }

    private Vector2 GetHeadingToBody(Rigidbody2D body)
    {
        return this.rigidbody2D.position - body.position;
    }
}
