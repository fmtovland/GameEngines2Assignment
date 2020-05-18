using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Influencer
{
	public GameObject target;
	Seek seeker;

	void Start()
	{
		seeker=gameObject.AddComponent<Seek>();
	}
	
	public override Vector3 GetForce(Boid boid)
	{
		seeker.target=target.transform.position;
		return seeker.GetForce(boid);
	}
}
