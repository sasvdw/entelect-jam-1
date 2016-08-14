using UnityEngine;

public class WrapAroundScreen : MonoBehaviour
{
    private CameraBounds cameraBounds;

    // Use this for initialization
	void Start ()
	{
	    this.cameraBounds = Camera.main.GetComponent<CameraBounds>();
	}
	
	// Update is called once per frame
	void Update () {
	    var pos = this.transform.position;

        if (pos.x < this.cameraBounds.Left)
	    {
	        pos.x = this.cameraBounds.Right;
	    }else if (pos.x > this.cameraBounds.Right)
	    {
	        pos.x = this.cameraBounds.Left;
	    }

	    if (pos.y > this.cameraBounds.Top)
	    {
	        pos.y = this.cameraBounds.Bottom;
	    }else if (pos.y < this.cameraBounds.Bottom)
	    {
	        pos.y = this.cameraBounds.Top;
	    }

	    this.transform.position = pos;
	}
}
