using UnityEngine;
using System.Collections;

public class PlayerShootLasers : MonoBehaviour {

    public Transform shot;
    public float energyCostPerShot = 10.0f;
    public float energyPerSecond = 20.0f;
    public float speedShot = 10.0f;

    private Transform leftGun;
    private Transform rightGun;
    private float energy = 0.0f;

	void Start () {
        leftGun = transform.FindChild("LeftGun");
        rightGun = transform.FindChild("RightGun");
        energy = energyCostPerShot;
	}
	
	void Update () {
	    if (energy < energyCostPerShot) {
            energy += Time.deltaTime * energyPerSecond;
            return;
        }

        if (Input.GetButton("Fire1")) {
            energy -= energyCostPerShot;
            var eulerAngles = transform.eulerAngles;
            var shot1 = Instantiate(shot, leftGun.position, Quaternion.Euler(eulerAngles)) as Transform;
            var shot2 = Instantiate(shot, rightGun.position, Quaternion.Euler(eulerAngles)) as Transform;

            var force = new Vector2(0, speedShot);
            var rot = Quaternion.Euler(eulerAngles);
            Vector2 forceToApply = rot*force;
            shot1.GetComponent<Rigidbody2D>().AddForce(forceToApply);
            shot2.GetComponent<Rigidbody2D>().AddForce(forceToApply);

            var shipCollider = GetComponent<Collider2D>();
            shot1.GetComponent<LaserBoltOnCollisionDestroy>().SetOrigin(shipCollider);
            shot2.GetComponent<LaserBoltOnCollisionDestroy>().SetOrigin(shipCollider);
        }
    }
}
