using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : Influencer
{
	Seek seeker;
	
	void Start()
	{
		seeker=gameObject.AddComponent<Seek>();
	}
	
	public override Vector3 GetForce(Boid boid)
	{
		seeker.target=boid.transform.position + boid.transform.forward;
		return seeker.GetForce(boid);
	}
}
