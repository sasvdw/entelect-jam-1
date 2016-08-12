using UnityEngine;
using System.Collections;

public class DestroyOffScreen : MonoBehaviour {

    private Renderer objectRenderer;

	// Use this for initialization
	void Start () {
        objectRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!objectRenderer.isVisible) {
            Destroy(gameObject);
        }
	}
}
