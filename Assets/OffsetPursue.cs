using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : Influencer
{
	public Vector3 offset;
	public GameObject target;
	public Arrive arriver;
	public bool stop_on_arrival=true;
	
	void Start()
	{
		arriver=gameObject.AddComponent<Arrive>();
		arriver.active=active;
		arriver.stop_on_arrival=stop_on_arrival;
	}

	public override Vector3 GetForce(Boid boid)
	{
		active=arriver.active;
		Vector3 desired = Vector3.zero;

		arriver.target = target.transform.position+offset;
		desired+=arriver.GetForce(boid);

		return desired-boid.velocity;
	}
}
