using UnityEngine;

public class PlayerOffScreenCamera : MonoBehaviour
{
    public Transform Player;
    private Camera camera;
    private Renderer playerRenderer;

    // Use this for initialization
	void Start ()
	{
	    this.camera = GetComponent<Camera>();
	    this.playerRenderer = Player.GetComponent<Renderer>();

	    this.camera.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.camera.enabled = !this.playerRenderer.isVisible;
        Debug.Log(this.camera.enabled);
	}

    void LateUpdate()
    {
        this.camera.transform.position = Player.position;
    }
}
