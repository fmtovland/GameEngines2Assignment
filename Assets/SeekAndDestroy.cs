using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndDestroy : Influencer
{
	public float seekrange=200;
	public int enemy_layer;

	GoForward goForward;
	Chase chaser;
	
	void Start()
	{
		goForward=gameObject.AddComponent<GoForward>();
		chaser=gameObject.AddComponent<Chase>();
	}

	void Update()
	{
		RaycastHit hit;

		if (Physics.SphereCast(transform.position, seekrange, transform.forward, out hit, seekrange, enemy_layer))
		{
			Debug.Log(hit.collider.tag);
			if (hit.collider != null)
			{
				chaser.target=hit.collider.gameObject;
			}
		}
	}

	public override Vector3 GetForce(Boid boid)
	{
		if(chaser.target!=null)
		{
			return chaser.GetForce(boid);
		}
		else
		{
			return goForward.GetForce(boid);
		}
	}
}
