using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : Influencer
{
	public Vector3 offset;
	public GameObject target;

	public override Vector3 GetForce(Boid boid)
	{
		Vector3 toTarget = target.transform.position - boid.transform.position + offset;
		Vector3 desired = toTarget.normalized * boid.maxSpeed;
		float distanceToTarget = Vector3.Distance(toTarget,boid.transform.position);

		if(distanceToTarget>1) return desired - boid.velocity;
		else return Vector3.zero;
	}
}
