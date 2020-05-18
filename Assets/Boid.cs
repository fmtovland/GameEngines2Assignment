using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
	public Vector3 velocity = Vector3.zero;
	public Vector3 acceleration = Vector3.zero;
	public Vector3 force = Vector3.zero;

	public float mass = 1.0f;
	public float maxSpeed = 5;
	public float speed = 0;

	[Range(0.0f, 10.0f)]
	public float banking = 0.1f;
	public float damping = 0.1f;

	public Influencer[] influencers;

	public Vector3 CalculateForce()
	{
		Vector3 force = Vector3.zero;
		foreach(Influencer influencer in influencers) if(influencer.active)
		{
			force+=influencer.GetForce(this);
		}

		return force;
	}

	protected void Start()
	{
		foreach(Influencer influencer in influencers)
		{
			influencer.Init();
		}
	}

	// Update is called once per frame
	protected void Update()
	{
		force = CalculateForce();
		acceleration = force / mass;
		velocity += acceleration * Time.deltaTime;

		transform.position += velocity * Time.deltaTime;
		speed = velocity.magnitude;
		if (speed > 0)
		{
			Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
			transform.LookAt(transform.position + velocity, tempUp);
			//transform.forward = velocity;
			velocity -= (damping * velocity * Time.deltaTime);
		}
	}
}
