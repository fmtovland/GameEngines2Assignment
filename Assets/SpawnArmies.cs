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
			s.spawnShips();
		}
		Destroy(this);
	}
}
