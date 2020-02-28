using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Influencer : MonoBehaviour
{
	public bool active=false;
	public abstract Vector3 GetForce(Boid boid);
	public virtual void Init(){}
}
