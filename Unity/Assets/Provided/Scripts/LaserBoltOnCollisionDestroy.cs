using UnityEngine;
using System.Collections;

public class LaserBoltOnCollisionDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Kaboom!");
        Destroy(collider.gameObject);
        Destroy(this.gameObject);
    }
}
