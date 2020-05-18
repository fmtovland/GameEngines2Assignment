using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : Influencer
{
	public Vector3 target;
	public float slowingDistance = 10;
	public bool stop_on_arrival=true;

	public override Vector3 GetForce(Boid boid)
	{
		slowingDistance = 10 + boid.speed;
		Vector3 toTarget = target - boid.transform.position;
		float dist = toTarget.magnitude;
		if(dist<.1f)
		{
			boid.velocity=Vector3.zero;
			if(stop_on_arrival) active=false;
			return Vector3.zero;
		}

		float ramped = (dist / slowingDistance) * boid.maxSpeed;
		float clamped = Mathf.Min(ramped, boid.maxSpeed);
		Vector3 desired = (toTarget / dist) * clamped;

		return desired - boid.velocity;
	}
}
