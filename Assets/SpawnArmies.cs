using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArmies : MonoBehaviour
{
	public Spawner[] spawners;
	
	public void OnTriggerEnter(Collider collider)
	{
		foreach(Spawner s in spawners)
		{
			try
			{
				s.spawnArmy();
			}
			catch(System.Exception e)
			{
				Debug.LogException(e);
			}
		}

		Destroy(this);
	}
}
