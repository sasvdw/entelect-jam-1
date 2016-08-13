using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float Left { get { return left; } }
    public float Right { get { return right; } }
    public float Top { get { return top; } }
    public float Bottom { get { return bottom; } }

    private float left;
    private float right;
    private float top;
    private float bottom;

    // Use this for initialization
    void Start()
    {
        var horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        var vertExtent = Camera.main.orthographicSize;

        left = this.transform.position.x - horzExtent;
        right = this.transform.position.x + horzExtent;
        top = this.transform.position.y + vertExtent;
        bottom = this.transform.position.y - vertExtent;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
