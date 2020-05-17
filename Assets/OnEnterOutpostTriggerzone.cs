using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterOutpostTriggerzone : MonoBehaviour
{
	public void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag("outpost_triggerzone"))
		{
			GetComponent<LineRenderer>().enabled=true;
		}
	}
}
