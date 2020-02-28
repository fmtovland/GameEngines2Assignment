using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Influencer
{
	public Vector3 target;

	public override Vector3 GetForce(Boid boid)
	{
		Vector3 toTarget = target - boid.transform.position;
		Vector3 desired = toTarget.normalized * boid.maxSpeed;

		return desired - boid.velocity;
	}
}
