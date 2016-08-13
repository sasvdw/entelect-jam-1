using UnityEngine;

public class LaserBoltOnCollisionDestroy : MonoBehaviour {
    private Collider2D origin;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider == origin)
        {
            return;
        }
        Destroy(collider.gameObject);
        Destroy(this.gameObject);
    }

    public void SetOrigin(Collider2D origin)
    {
        this.origin = origin;
    }
}
