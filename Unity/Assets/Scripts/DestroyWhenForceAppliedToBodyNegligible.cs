using System.Linq;
using UnityEngine;

public class DestroyWhenForceAppliedToBodyNegligible : MonoBehaviour
{
    private BodyGravity bodyGravity;
    private Renderer renderer;

    // Use this for initialization
	void Start ()
	{
	    this.bodyGravity = GetComponent<BodyGravity>();
	    this.renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (renderer.isVisible)
	    {
	        return;
	    }

	    var countOfNegligibleForces = this.bodyGravity.ForceAppliedToBodies.Count(x => x.Value <= 0.1f);

	    if (countOfNegligibleForces == 0)
	    {
	        return;
	    }

	    var percentageNegligible = countOfNegligibleForces/this.bodyGravity.ForceAppliedToBodies.Count*100;

	    if (percentageNegligible < 100)
	    {
	        return;
	    }

	    Debug.Log("Destroying " + GetInstanceID());
	    Destroy(gameObject);
	}
}
