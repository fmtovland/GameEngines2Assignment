using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : Influencer
{
	public Vector3 target;
	public float slowingDistance = 10;

	public override Vector3 GetForce(Boid boid)
	{
		Vector3 toTarget = target - boid.transform.position;
		float dist = toTarget.magnitude;

		float ramped = (dist / slowingDistance) * boid.maxSpeed;
		float clamped = Mathf.Min(ramped, boid.maxSpeed);
		Vector3 desired = (toTarget / dist) * clamped;

		return desired - boid.velocity;
	}
}
