using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterOutpostPrometheus : MonoBehaviour
{
	public TauriSpawner ts;

	public void OnTriggerEnter(Collider collider)
	{
		Debug.Log(collider.tag);

		if(collider.CompareTag("outpost_triggerzone"))
		{
			ts.setAttackMode();
			Destroy(this);
		}
	}
}
