using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArmies : MonoBehaviour
{
	public Spawner[] spawners;
	public GameObject drone;
	public float drone_spawn_delay;

	bool triggered=false;

	public void OnTriggerEnter(Collider collider)
	{
		if(triggered) return;
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

		StartCoroutine(spawnDrones());
		triggered=true;
	}
	
	IEnumerator spawnDrones()
	{
		yield return new WaitForSeconds(drone_spawn_delay);

		for(int i=0; i<100; i++)
		{
			Drone d=Instantiate(drone).GetComponent<Drone>();
			d.target=new Vector3(0,1000,0);
			yield return new WaitForSeconds(.1f);
		}
	}
}
