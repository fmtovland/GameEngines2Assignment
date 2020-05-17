using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : Influencer
{
	public Vector3 offset;
	public GameObject target;
	public Arrive arriver;

	public override Vector3 GetForce(Boid boid)
	{
		Vector3 desired = Vector3.zero;
		Vector3 v = target.transform.position + offset;

		arriver.target = v;
		desired+=arriver.GetForce(boid);

		return desired-boid.velocity;
	}
}
