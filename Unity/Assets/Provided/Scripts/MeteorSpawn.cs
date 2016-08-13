﻿using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public Transform[] Meteors;
    public float SpawnRate = 10.0f;

    private readonly Transform[] spawns = new Transform[4];
    private float timeCount;


    // Use this for initialization
	void Start ()
	{
	    timeCount = 60.0f/SpawnRate;

	    var cameraBounds = Camera.main.GetComponent<CameraBounds>();

        var left = this.transform.FindChild("Left");
	    var right = this.transform.FindChild("Right");
        var top = this.transform.FindChild("Top");
        var bottom = this.transform.FindChild("Bottom");

	    var leftPos = left.position;
	    var rightPos = right.position;
	    var topPos = top.position;
	    var bottomPos = bottom.position;

	    leftPos.x = cameraBounds.Left;
	    rightPos.x = cameraBounds.Right;
	    topPos.y = cameraBounds.Top;
	    bottomPos.y = cameraBounds.Bottom;

	    left.position = leftPos;
	    right.position = rightPos;
	    top.position = topPos;
	    bottom.position = bottomPos;

	    this.spawns[0] = left;
	    this.spawns[1] = right;
	    this.spawns[2] = top;
	    this.spawns[3] = bottom;
	}

    // Update is called once per frame
	void Update ()
	{
	    timeCount += Time.deltaTime;

	    if (timeCount >= 60.0f / SpawnRate)
	    {
	        SpawnMeteor();
	    }
	}

    private void SpawnMeteor()
    {
        var indexSpawn = (int) (Random.value* (this.spawns.Length - 1));
        var indexMeteor = (int) (Random.value*(this.Meteors.Length - 1));

        var meteorToSpawn = this.Meteors[indexMeteor];
        var spawnPosition = this.spawns[indexSpawn].position;

        Instantiate(meteorToSpawn, spawnPosition, Quaternion.identity);

        timeCount = 0.0f;
    }
}
