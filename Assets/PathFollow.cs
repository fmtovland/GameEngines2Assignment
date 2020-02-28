using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : Influencer
{
	public Vector3[] path;
	public int currentWaypoint=0;
	public int arriveDistance=10;

	public Seek seeker;
	public Arrive arriver;

	public override void Init()
	{
		seeker.target=path[0];
		arriver.target=path[0];
		arriver.slowingDistance = 3*arriveDistance;
	}

	public override Vector3 GetForce(Boid boid)
	{
		if(Vector3.Distance(boid.transform.position,path[currentWaypoint])<arriveDistance)
		{
			currentWaypoint++;
			currentWaypoint%=path.Length;
			seeker.target=path[currentWaypoint];
			arriver.target=path[currentWaypoint];
		}

		return seeker.GetForce(boid)+arriver.GetForce(boid);
	}
}
