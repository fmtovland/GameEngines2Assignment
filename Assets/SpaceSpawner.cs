using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawner : MonoBehaviour
{
	public int hataks,drones;
	public GameObject hatak,drone;

	void Start()
	{
		GameObject o;

		for(int i=0; i<hataks; i++)
		{
			o = Instantiate(hatak);
			o.transform.position=randpoint();
			
			StartCoroutine(spawnDrones(o.transform.position));
		}
	}
	
	Vector3 randpoint()
	{
		return new Vector3(
									Random.Range(-250,250),
									Random.Range(0,150),
									Random.Range(0,200)
								);
	}
	
	IEnumerator spawnDrones(Vector3 target)
	{
		for(int j=0; j<drones; j++)
		{
			GameObject d=Instantiate(drone);
			d.GetComponent<Drone>().target=target;
			yield return new WaitForSeconds(.1f);
		}
	}
}
