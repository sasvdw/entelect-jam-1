using UnityEngine;
using System.Collections;

public class PlayerShootLasers : MonoBehaviour {

    public Transform shot;
    public float energyCostPerShot = 10.0f;
    public float energyPerSecond = 20.0f;

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
        }

        if (Input.GetButton("Fire1")) {
            energy -= energyCostPerShot;

            Instantiate(shot, leftGun);
            Instantiate(shot, rightGun);
        }
	}
}
