using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : Influencer
{
	public Vector3 offset;
	public GameObject target;
	public Arrive arriver;
	Transform transfoam;

	public override Vector3 GetForce(Boid boid)
	{
		Vector3 desired = Vector3.zero;
		transform.LookAt(target.transform.position);

		arriver.target = target.transform.position+offset;
		desired+=arriver.GetForce(boid);

		return desired-boid.velocity;
	}
}
