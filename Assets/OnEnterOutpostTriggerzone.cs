using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterOutpostTriggerzone : MonoBehaviour
{
	bool triggered=false;
	public Vector3 fleePoint;
	public float delay=60;
	LineRenderer lazer;

	void Start()
	{
		lazer=gameObject.GetComponent<LineRenderer>();
	}

	public void OnTriggerEnter(Collider collider)
	{
		if(triggered) return;

		if(collider.CompareTag("outpost_triggerzone"))
		{
			lazer.enabled=true;
			StartCoroutine(LeaveCountdown());
			triggered=true;
		}
	}

	IEnumerator LeaveCountdown()
	{
		yield return new WaitForSeconds(delay);
		lazer.enabled=false;
		Arrive a=transform.parent.gameObject.GetComponent<Arrive>();
		a.target=fleePoint;
		a.active=true;
	}
}
