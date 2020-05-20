using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPrometheusEnterOutpost : MonoBehaviour
{
	public Vector3 fleePoint;
	public float delay=70;

	void Start()
	{
		StartCoroutine(LeaveCountdown());
	}

	IEnumerator LeaveCountdown()
	{
		yield return new WaitForSeconds(delay);
		Arrive a=transform.gameObject.GetComponent<Arrive>();
		a.target=fleePoint;
		a.active=true;
	}
}
