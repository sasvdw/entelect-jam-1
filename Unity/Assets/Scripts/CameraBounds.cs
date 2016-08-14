using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float Left { get { return left; } }
    public float Right { get { return right; } }
    public float Top { get { return top; } }
    public float Bottom { get { return bottom; } }
    public bool IsReady { get { return isReady; } }

    private float left;
    private float right;
    private float top;
    private float bottom;
    private bool isReady;

    // Use this for initialization
    void Start()
    {
        var horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
        var vertExtent = Camera.main.orthographicSize;

        this.left = this.transform.position.x - horzExtent;
        this.right = this.transform.position.x + horzExtent;
        this.top = this.transform.position.y + vertExtent;
        this.bottom = this.transform.position.y - vertExtent;

        this.isReady = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
