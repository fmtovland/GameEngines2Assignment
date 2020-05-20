using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Boid
{
	Seek seeker;
	public Vector3 target;
	public int enemy_layer=1<<8;	//goauld
	public float max_distance_to_target=1500;

	void Start()
	{
		base.Start();
		seeker=gameObject.AddComponent<Seek>();
		seeker.active=true;
		seeker.target=target;
		influencers.Add(seeker);
	}
}
