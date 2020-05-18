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
		Vector3 r=Vector3.zero;
		seeker.target=target.transform.position;
		//r=seeker.GetForce(Boid boid);
		
		return r;
	}
}
